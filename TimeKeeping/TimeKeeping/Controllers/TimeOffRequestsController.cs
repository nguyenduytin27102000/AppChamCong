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
        private const string PENDING_STATUS = "pending";

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
            // thông thường sẽ lấy thông tin người đăng nhập bằng session,
            // ở đây phần đăng nhập chưa có, nên tạm thời sẽ lấy nhân viên ĐẦU TIÊN trong CSDL để làm mẫu
            // nếu phát triển thì nhớ thay đổi lại biến personnel này.
            var personnel = _context.Personnel.FirstOrDefault();

            // lấy các chính sách nghỉ phép đang áp dụng
            var applyTimeOffPolicies = personnel.PersonnelApplyTimeOffPolicies
                    .Where(a => DateTime.Compare(a.EffectiveDate, DateTime.Now.Date) <= 0).ToList();

            // lấy số ngày nghỉ cho phép chủa nhân viên
            var dayOffAllowedCount = applyTimeOffPolicies
                .Sum(a => a.NumberOfDaysOffLastYear + a.NumberOfDaysOffOffset + a.NumberOfDaysOffSeniority + a.NumberOfDaysOffStandard);

            ViewData["FormTimeOffId"] = new SelectList(_context.FormTimeOffs, "FormTimeOffId", "FormTimeOffName");
            ViewData["ManagerId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");

            // đưa dữ liệu số ngày nghỉ phép còn lại đến View
            ViewData["RemainDayOffCount"] = dayOffAllowedCount;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeOffRequestModel timeOffRequestModel, IFormCollection formData)
        {

            // thông thường sẽ lấy thông tin người đăng nhập bằng session,
            // ở đây phần đăng nhập chưa có, nên tạm thời sẽ lấy nhân viên ĐẦU TIÊN trong CSDL để làm mẫu
            // nếu phát triển thì nhớ thay đổi lại biến personnel này nếu đã có chức năng đăng nhập.
            var personnel = _context.Personnel.FirstOrDefault();

            // using mapper to map model view to model db
            TimeOffRequest timeOffRequest = _mapper.Map<TimeOffRequest>(timeOffRequestModel);

            // set timeoff request
            timeOffRequest.TimeOffRequestId = _identityFactory
                .GenerateId2(_context.TimeOffRequests.Max(m => m.TimeOffRequestId), "TOR");

            // thực tế thì sẽ lấy thông tin nhân viên bằng session khi nhân viên ấy đăng nhập vào
            // do chưa có chức năng đăng nhập nên dùng tạm là lấy thằng nhân viên đầu tiên trên CSDL
            // nhớ tùy chỉnh lại cái này nếu đã có chức năng đăng nhập
            timeOffRequest.PersonnelId = personnel.PersonnelId;

            timeOffRequest.TimeOffRequestStateId = _context
                .TimeOffRequestStates.Where(t => t.TimeOffRequestStateName.ToLower() == PENDING_STATUS)
                .Select(t => t.TimeOffRequestStateId).FirstOrDefault();// get pending state

            #region Xác định Ca làm việc của Công ty theo từng loại (Sáng, chiều, cả ngày)
            // get shifts
            var morning = _context.Shifts.Where(s => s.StartTime.Hour <= 9)
                .Select(s => new { Start = s.StartTime, End = s.EndTime })
                .FirstOrDefault();
            var afternoon = _context.Shifts.Where(s => s.StartTime.Hour >= 12)
                .Select(s => new { Start = s.StartTime, End = s.EndTime })
                .FirstOrDefault();
            var fullday = new { Start = morning.Start, End = afternoon.End };
            var shift = new { Morning = morning, Afternoon = afternoon, Fullday = fullday };
            #endregion

            // lấy các chính sách nghỉ phép đang áp dụng
            var applyTimeOffPolicies = personnel.PersonnelApplyTimeOffPolicies
                    .Where(a => DateTime.Compare(a.EffectiveDate, DateTime.Now.Date) <= 0).ToList();

            // lấy số ngày nghỉ cho phép chủa nhân viên
            var dayOffAllowedCount = applyTimeOffPolicies
                .Sum(a => a.NumberOfDaysOffLastYear + a.NumberOfDaysOffOffset + a.NumberOfDaysOffSeniority + a.NumberOfDaysOffStandard);

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

            int dayOffCount = (int)(toDate - fromDate).TotalDays + 1;

            #region Trường hợp nếu nghỉ quá số ngày cho phép
            // nếu số ngày nghỉ cho phép nhỏ hơn số ngày nghỉ mong muốn thì báo lỗi
            if (dayOffAllowedCount < dayOffCount)
            {
                // đưa dữ liệu số ngày nghỉ phép còn lại đến View
                ViewData["RemainDayOffCount"] = dayOffAllowedCount;
                ViewData["FormTimeOffId"] = new SelectList(_context.FormTimeOffs, "FormTimeOffId", "FormTimeOffName");
                ViewData["ManagerId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");
                ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "FullName");
                ViewBag.message = "Not allowed to take more than the allowed number of days";
                ViewBag.status = "danger";
                return View();
            }
            #endregion

            // kiểu ngày nghỉ (nguyên ngày, nửa ngày, tùy chọn) được lấy từ View
            int shiftOffTypeForm = timeOffRequestModel.Duration;
            
            string startOffHour = "";
            
            string endOffHour = "";

            #region Xác định loại ngày nghỉ
            // lấy dữ liệu từ form và đưa nó vào từng option để lưu vào CSDL
            switch (shiftOffTypeForm)
            {
                // trường hợp chọn nghỉ nguyên ngày
                case (int)ShiftOffType.FULLDAY:
                    startOffHour = $"{fullday.Start.Hour}:{fullday.Start.Minute.ToString().PadLeft(2, '0')}";
                    endOffHour = $"{fullday.End.Hour}:{fullday.End.Minute.ToString().PadLeft(2, '0')}";
                    break;
                // trường hợp nghỉ nửa ngày
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
                // trường hợp nghỉ thời gian tùy chọn trong ngày
                case (int)ShiftOffType.SPECIFY:
                    startOffHour = timeOffRequestModel.FromHour;
                    endOffHour = timeOffRequestModel.ToHour;
                    break;
                // các trường hợp khác thì cho nghỉ nguyên ngày
                default:
                    startOffHour = $"{fullday.Start.Hour}:{fullday.Start.Minute.ToString().PadLeft(2, '0')}";
                    endOffHour = $"{fullday.End.Hour}:{fullday.End.Minute.ToString().PadLeft(2, '0')}";
                    break;
            }
            #endregion

            // để giữ lại ID của ngày nghỉ, phục vụ cho những lần lặp
            // tránh trường hợp bị mất dấu ID
            var dayoffCurrentId = _context.DayOffs.Max(m => m.DayOffId);

            for (int i = 0; i < dayOffCount; i++)
            {
                DayOff dayOff = new DayOff()
                {
                    DayOffId = _identityFactory.GenerateId2(dayoffCurrentId, "DOF"),
                    TimeOffRequestId = timeOffRequest.TimeOffRequestId,
                    DayOffAt = fromDate.AddDays(i),
                    FromHour = startOffHour,
                    ToHour = endOffHour,
                    Active = true
                };
                dayoffCurrentId = dayOff.DayOffId;
                offDays.Add(dayOff);
            }

            // dùng transaction tránh trường hợp insert vào CSDL bị lỗi mà CSDL lại bị thay đổi
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.TimeOffRequests.AddAsync(timeOffRequest);
                _context.SaveChanges(true);
                await _context.DayOffs.AddRangeAsync(offDays);
                _context.SaveChanges(true);


                transaction.Commit();
                ViewBag.message = "You have successfully sent time off request";
                ViewBag.status = "success";
            }
            catch (Exception ex)
            {
                ViewBag.message = $"Sorry, an error occurred: {ex.Message}";
                ViewBag.status = "danger";
            }

            // đưa dữ liệu số ngày nghỉ phép còn lại đến View
            ViewData["RemainDayOffCount"] = dayOffAllowedCount;
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
