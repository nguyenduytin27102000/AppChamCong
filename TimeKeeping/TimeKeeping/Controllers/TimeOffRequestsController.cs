using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeKeeping.Models;
using TimeKeeping.Services;
using TimeKeeping.Supporters;
using TimeKeeping.ViewModels;

namespace TimeKeeping.Controllers
{
    public class TimeOffRequestsController : Controller
    {
        private readonly TimeKeepingDBContext _context;
        private readonly IMapper _mapper;
        private readonly IdentityFactory _identityFactory;
        private readonly IHostingEnvironment _hostingEnvironment;

        public TimeOffRequestsController(TimeKeepingDBContext context, IMapper mapper,
                    IdentityFactory identityFactory, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _identityFactory = identityFactory;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Create()
        {
            ViewData["FormTimeOffId"] = new SelectList(_context.FormTimeOffs, "FormTimeOffId", "FormTimeOffName");
            ViewData["ManagerId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeOffRequestModel timeOffRequestModel, IFormCollection formData)
        {
            // using mapper to map model view to model db
            TimeOffRequest timeOffRequest = _mapper.Map<TimeOffRequest>(timeOffRequestModel);

            // set timeoff request
            timeOffRequest.TimeOffRequestId = _identityFactory
                .GenerateId(_context.TimeOffRequests.Max(m => m.TimeOffRequestId), "TOR");
            timeOffRequest.PersonnelId = _context.Personnel
                .FirstOrDefault().PersonnelId; // lấy thông tin bằng Session (tạm thời là lấy thằng đầu tiên)
            timeOffRequest.TimeOffRequestStateId = _context
                .TimeOffRequestStates.Where(t => t.TimeOffRequestStateName.ToLower() == "pending")
                .Select(t => t.TimeOffRequestStateId).FirstOrDefault();// get pending state

            // get shifts
            var morning = _context.Shifts.Where(s => s.StartTime.Hour <= 9)
                .Select(s => new { Start = s.StartTime, End = s.EndTime })
                .FirstOrDefault();
            var afternoon = _context.Shifts.Where(s => s.StartTime.Hour >= 12)
                .Select(s => new { Start = s.StartTime, End = s.EndTime })
                .FirstOrDefault();
            var fullday = new { Start = morning.Start, End = afternoon.End };
            var shift = new { Morning = morning, Afternoon = afternoon, Fullday = fullday };


            // save a attachment
            if (timeOffRequestModel.Attachment != null)
            {
                string extension = Path.GetExtension(timeOffRequestModel.Attachment.FileName);
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "storage", "attachments", 
                    timeOffRequest.TimeOffRequestId + extension);
                using (var stream = System.IO.File.Create(uploadFolder))
                {
                    await timeOffRequestModel.Attachment.CopyToAsync(stream);
                    timeOffRequest.Attachment = timeOffRequest.TimeOffRequestId + extension;
                }
            }
            // insert shift off
            var offDays = new List<DayOff>();

            DateTime fromDate = timeOffRequestModel.FromDate;
            DateTime toDate = timeOffRequestModel.ToDate;

            int dayOffCount = (int)(toDate - fromDate).TotalDays;
            int shiftOffTypeForm = timeOffRequestModel.Duration;
            string startOffHour = "";
            string endOffHour = "";
            switch (shiftOffTypeForm)
            {
                case (int)ShiftOffType.FULLDAY:
                    // remember fix here
                    startOffHour = $"{fullday.Start.Hour}:{fullday.Start.Minute.ToString().PadLeft(2, '0')}";
                    endOffHour = $"{fullday.End.Hour}:{fullday.End.Minute.ToString().PadLeft(2, '0')}";
                    break;

                case (int)ShiftOffType.HALFDAY:
                    int half = int.Parse(timeOffRequestModel.HalfDay);
                    if(half == 1)
                    {
                        startOffHour = $"{morning.Start.Hour}:{morning.Start.Minute.ToString().PadLeft(2, '0')}";
                        endOffHour = $"{morning.End.Hour}:{morning.End.Minute.ToString().PadLeft(2, '0')}"; ;
                    }
                    else
                    {
                        startOffHour = $"{afternoon.Start.Hour}:{afternoon.Start.Minute.ToString().PadLeft(2, '0')}";
                        endOffHour = $"{afternoon.End.Hour}:{afternoon.End.Minute.ToString().PadLeft(2, '0')}"; ;
                    }
                    break;

                case (int)ShiftOffType.SPECIFY:
                    startOffHour = timeOffRequestModel.FromHour;
                    endOffHour = timeOffRequestModel.ToHour;
                    break;

                default:
                    startOffHour = $"{fullday.Start.Hour}:{fullday.Start.Minute.ToString().PadLeft(2, '0')}";
                    endOffHour = $"{fullday.End.Hour}:{fullday.End.Minute.ToString().PadLeft(2, '0')}";
                    break;
            }
            var dayoffCurrentId = _context.DayOffs.Max(m => m.DayOffId);

            for (int i = 0; i < dayOffCount; i++)
            {
                DayOff dayOff = new DayOff()
                {
                    DayOffId = _identityFactory.GenerateId(dayoffCurrentId, "DOF"),
                    TimeOffRequestId = timeOffRequest.TimeOffRequestId,
                    DayOffAt = fromDate.AddDays(i),
                    FromHour = startOffHour,
                    ToHour = endOffHour,
                    Active = true
                };
                dayoffCurrentId = dayOff.DayOffId;
                offDays.Add(dayOff);
            }


            var t1 = _context.TimeOffRequests.AddRangeAsync(timeOffRequest);
            var t2 = _context.DayOffs.AddRangeAsync(offDays);
            try
            {
                await Task.WhenAll(t1, t2);
                _context.SaveChanges(true);
                ViewBag.message = "You have successfully sent time off request";
                ViewBag.status = "success";
            }
            catch (Exception ex)
            {
                ViewBag.message = $"Sorry, an error occurred: {ex.Message}";
                ViewBag.status = "danger";
            }

            //ViewData["Shifts"] = GetShifts().Result;
            ViewData["FormTimeOffId"] = new SelectList(_context.FormTimeOffs, "FormTimeOffId", "FormTimeOffName");
            ViewData["ManagerId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");
            return View();
        }

        private bool TimeOffRequestExists(string id)
        {
            return _context.TimeOffRequests.Any(e => e.TimeOffRequestId == id);
        }
    }
}
