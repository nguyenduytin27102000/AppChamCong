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

            var listRequest = await _context.TimeOffRequests.ToListAsync();
            return View(listRequest);
        }

        public async Task<IActionResult> Edit(string id)
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
            var personnel = _context.Personnel.SingleOrDefault(ns => ns.PersonnelId == timeOffRequest.PersonnelId);
            ViewBag.PersonName = personnel.LastName + " " + personnel.FirstName;
            //ViewBag.PersonName = timeOffRequest.Personnel.LastName + " " + timeOffRequest.Personnel.FirstName;
            var form = _context.FormTimeOffs.SingleOrDefault(np => np.FormTimeOffId == timeOffRequest.FormTimeOffId);
            ViewBag.FormTimeOffName = form.FormTimeOffName;
            var statusName = _context.TimeOffRequestStates.SingleOrDefault(st => st.TimeOffRequestStateId == timeOffRequest.TimeOffRequestStateId).TimeOffRequestStateName;
            ViewBag.status = statusName;
            var manager = _context.Personnel.SingleOrDefault(ns => ns.PersonnelId == timeOffRequest.ManagerId);
            ViewBag.ManagerName = manager.LastName + " " + manager.FirstName;
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
            _context.Update(timeOffRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "ApproveTimeoff", new { id = id });
        }
    }
}
