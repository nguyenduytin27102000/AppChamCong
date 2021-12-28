using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Models;

namespace TimeKeeping.Controllers
{
    public class FeedbackCheckinController : Controller
    {
        private readonly TimeKeepingDBContext _context;

        public FeedbackCheckinController(TimeKeepingDBContext context)
        {
            _context = context;
        }
        /*
        public string GetTimeKeepingFeedbackId()
        {
            TimeKeepingFeedback tk = _context.TimeKeepingFeedbacks.ToList().Last();
            //KhachHang kh = db.KhachHangs.ToList().Last();
            int id = Convert.ToInt32(tk.TimeKeepingFeedbackId) + 1;
            string nextid = id.ToString();
            return nextid;
        }*/
        public string GetTimeKeepingFeedbackId(string f) // f is firt in char id. vd: FB001. 'FB' is f 
        {
            string nextId;
            int temp;
            // which table ??
            TimeKeepingFeedback tk = _context.TimeKeepingFeedbacks.ToList().Last();
            //
            nextId = tk.TimeKeepingFeedbackId.Substring(2, 3);
            temp = Int32.Parse(nextId);
            temp = temp + 1;
            nextId = temp.ToString();
            if (nextId.Length == 2)
                nextId = "0" + nextId;
            else if (nextId.Length == 1)
                nextId = "00" + nextId;
            nextId = f + nextId;
            return nextId;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListCheckin()
        {

            var listcheckin = await _context.Checkins.ToListAsync();
            return View(listcheckin);
        }
        [HttpGet]
        public IActionResult Feedback(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.checkinId = id;
            //ViewData["CheckinId"] = _context.Checkins.SingleOrDefault(ck => ck.CheckinId == id);
           // ViewData["TimeOffRequestStateId"] = new SelectList(_context.TimeOffRequestStates.Where(s => s.TimeOffRequestStateId == "001"), "TimeOffRequestStateId", "TimeOffRequestStateId");
            return View();
        }

        // POST: TimeKeepingFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Feedback([Bind("TimeKeepingFeedbackId,CheckinId,Reason,Time,TimeOffRequestStateId,Active")] TimeKeepingFeedback timeKeepingFeedback)
        {
            timeKeepingFeedback.TimeKeepingFeedbackId = GetTimeKeepingFeedbackId("FB");
            timeKeepingFeedback.Time = DateTime.Now;
            ViewBag.checkinId = timeKeepingFeedback.CheckinId;
            timeKeepingFeedback.TimeOffRequestStateId = "001";//Pending approve
            if (timeKeepingFeedback.Reason == null)
            {
                ViewBag.Notify = "Error: You have not entered comments!";
                return View(timeKeepingFeedback);
            }
            
            if (ModelState.IsValid)
            {
                _context.Add(timeKeepingFeedback);
                await _context.SaveChangesAsync();
                ViewBag.Notify = "Successful";
                return View(timeKeepingFeedback);
            }
            ViewData["CheckinId"] = new SelectList(_context.Checkins.Where(c => c.CheckinId == timeKeepingFeedback.CheckinId), "CheckinId", "CheckinId");
            ViewData["TimeOffRequestStateId"] = new SelectList(_context.TimeOffRequestStates.Where(s => s.TimeOffRequestStateId == "001"), "TimeOffRequestStateId", "TimeOffRequestStateId");
            ViewBag.Notify = "Error";
            return View(timeKeepingFeedback);
        }

        public async Task<IActionResult> ListFeedback(string id)
        {
            var list = _context.TimeKeepingFeedbacks.Where(t => t.CheckinId == id);
            return View(await list.ToListAsync());
        }

    }
}
