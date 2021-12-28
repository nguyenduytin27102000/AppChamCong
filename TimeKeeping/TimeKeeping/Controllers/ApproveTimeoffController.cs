using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Models;

namespace TimeKeeping.Controllers
{
    public class ApproveTimeoffController : Controller
    {
        private readonly TimeKeepingDBContext _context;

        public ApproveTimeoffController(TimeKeepingDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //var listRequest = _context.YeuCauNghiPheps.Where(yc => yc.MaNguoiQuanLy == session["userId"]).ToListAsync();
            var listRequest = await _context.TimeOffRequests.ToListAsync();
            return View(listRequest);
        }

        public async Task<IActionResult> Edit(string id)
        {
            //string id = "TOR01";
            if (id == null)
            {
                return NotFound();
            }

            var timeOffRequest = await _context.TimeOffRequests.FindAsync(id);
            if (timeOffRequest == null)
            {
                return NotFound();
            }
            var nhansu = _context.Personnel.SingleOrDefault(ns => ns.PersonnelId == timeOffRequest.PersonnelId);
            ViewBag.PersonName = nhansu.LastName + " " + nhansu.FirstName;
            //ViewBag.PersonName = timeOffRequest.Personnel.LastName + " " + timeOffRequest.Personnel.FirstName;
            var form = _context.FormTimeOffs.SingleOrDefault(np => np.FormTimeOffId == timeOffRequest.FormTimeOffId);
            ViewBag.FormTimeOffName = form.FormTimeOffName;
            var statusName = _context.TimeOffRequestStates.SingleOrDefault(st => st.TimeOffRequestStateId == timeOffRequest.TimeOffRequestStateId).TimeOffRequestStateName;
            ViewBag.status = statusName;
            return View(timeOffRequest);
        }

        public async Task<IActionResult> UpdateStatus(string id, string status)
        {
            if (id == null)
            {
                return NotFound();
            }
            var timeOffRequest = await _context.TimeOffRequests.FindAsync(id);
            if (timeOffRequest == null)
            {
                return NotFound();
            }

            timeOffRequest.TimeOffRequestStateId = status;
            var statusName = _context.TimeOffRequestStates.SingleOrDefault(st => st.TimeOffRequestStateId == status).TimeOffRequestStateName;

            if (status == "Approved")
            {
                //Update remaining days off of employee in personnelApplyTimeOffPolicy table
                /*
                var personnelApplyTimeOffPolicy = _context.PersonnelApplyTimeOffPolicies.SingleOrDefault(ns => ns.PersonnelId == timeOffRequest.PersonnelId);
               
                var formTimeOff = _context.FormTimeOffs.SingleOrDefault(np => np.FormTimeOffId == timeOffRequest.FormTimeOffId);
                var numday = formTimeOff.LimitedDaysOff;

                if (personnelApplyTimeOffPolicy.NumberOfDaysOffLastYear > 0 && personnelApplyTimeOffPolicy.NumberOfDaysOffLastYear >= numday) personnelApplyTimeOffPolicy.NumberOfDaysOffLastYear -= numday;
                else if (personnelApplyTimeOffPolicy.NumberOfDaysOffSeniority > 0 && personnelApplyTimeOffPolicy.NumberOfDaysOffSeniority >= numday) personnelApplyTimeOffPolicy.NumberOfDaysOffSeniority -= numday;
                else if (personnelApplyTimeOffPolicy.NumberOfDaysOffStandard > 0 && personnelApplyTimeOffPolicy.NumberOfDaysOffStandard >= numday) personnelApplyTimeOffPolicy.NumberOfDaysOffStandard -= numday;

                _context.Update(personnelApplyTimeOffPolicy);
                */
            }
            _context.Update(timeOffRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "ApproveTimeoff", new { id = id });
        }
    }
}
