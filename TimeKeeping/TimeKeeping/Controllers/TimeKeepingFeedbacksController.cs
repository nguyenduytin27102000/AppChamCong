using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping.Models;

namespace TimeKeeping.Controllers
{
    public class TimeKeepingFeedbacksController : Controller
    {
        private readonly TimeKeepingDBContext _context;

        public TimeKeepingFeedbacksController(TimeKeepingDBContext context)
        {
            _context = context;
        }
        public string GetTimeKeepingFeedbackId()
        {
            TimeKeepingFeedback tk = _context.TimeKeepingFeedbacks.ToList().Last();
            //KhachHang kh = db.KhachHangs.ToList().Last();
            int id = Convert.ToInt32(tk.TimeKeepingFeedbackId) + 1;
            string nextid = id.ToString();
            return nextid;
        }

        // GET: TimeKeepingFeedbacks

        // View FeedBack Timekeeping. Just LINQ from TimeKeepingFeedbacks table and join table related
        public async Task<IActionResult> Index()
        {
            //var timeKeepingDBContext = _context.TimeKeepingFeedbacks.Include(t => t.Checkin).Include(t => t.TimeOffRequestState);
            var feedBacks = (from f in _context.TimeKeepingFeedbacks
                             join c in _context.Checkins on f.CheckinId equals c.CheckinId
                         join s in _context.TimeOffRequestStates on f.TimeOffRequestStateId equals s.TimeOffRequestStateId
                         join p in _context.Personnel on c.PersonnelId equals p.PersonnelId
                         where f.Active == true 
                         select new TimeKeepingFeedbackWithView
                         {
                             TimeKeepingFeedbackId = f.TimeKeepingFeedbackId,
                             PersonnelId = p.PersonnelId,
                             CheckinId = c.CheckinId,
                             TimeOffRequestStateName = s.TimeOffRequestStateName,
                             LastName = p.LastName,
                             Time = f.Time,
                             Reason = f.Reason,
                             TimeOffRequestStateId = s.TimeOffRequestStateId
                         }).OrderBy(x => x.TimeOffRequestStateId);



            return View(feedBacks);
        }

        // GET: TimeKeepingFeedbacks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeKeepingFeedback = await _context.TimeKeepingFeedbacks
                .Include(t => t.Checkin)
                .Include(t => t.TimeOffRequestState)
                .FirstOrDefaultAsync(m => m.TimeKeepingFeedbackId == id);
            if (timeKeepingFeedback == null)
            {
                return NotFound();
            }

            return View(timeKeepingFeedback);
        }

        // GET: TimeKeepingFeedbacks/Create


        public IActionResult Create(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["CheckinId"] = new SelectList(_context.Checkins.Where(c => c.CheckinId == id), "CheckinId", "CheckinId");
            ViewData["TimeOffRequestStateId"] = new SelectList(_context.TimeOffRequestStates.Where(s => s.TimeOffRequestStateId == "001"), "TimeOffRequestStateId", "TimeOffRequestStateId");

            return View();
        }

        // POST: TimeKeepingFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create([Bind("TimeKeepingFeedbackId,CheckinId,Reason,Time,TimeOffRequestStateId,Active")] TimeKeepingFeedback timeKeepingFeedback)
        {
            if(timeKeepingFeedback.Reason == null)
            {
                ViewBag.Notify = "Error: You have not entered comments!";
                return View(timeKeepingFeedback);
            }
            timeKeepingFeedback.TimeKeepingFeedbackId = GetTimeKeepingFeedbackId();
            timeKeepingFeedback.CheckinId = "CK1";
            timeKeepingFeedback.Time = DateTime.Now;
            //timeKeepingFeedback.TimeOffRequestStateId = "TOR1";
            if (ModelState.IsValid)
            {
                _context.Add(timeKeepingFeedback);
                await _context.SaveChangesAsync();
                ViewBag.Notify = "Successful";
                return View(timeKeepingFeedback); ;
            }

            ViewData["CheckinId"] = new SelectList(_context.Checkins.Where(c => c.CheckinId == timeKeepingFeedback.CheckinId), "CheckinId", "CheckinId");
            ViewData["TimeOffRequestStateId"] = new SelectList(_context.TimeOffRequestStates.Where(s => s.TimeOffRequestStateId == "001"), "TimeOffRequestStateId", "TimeOffRequestStateId");
            ViewBag.Notify = "Error";
            return View(timeKeepingFeedback);
        }
        
        public async Task<IActionResult> Approval(string id) { //id is a CheckinId 
           if (id == null)
            {
                return NotFound();
            }
            var timeKeepingFeedback = _context.TimeKeepingFeedbacks.Where(f => f.CheckinId == id);
            if (timeKeepingFeedback == null)
            {
                return NotFound();
            }
            foreach (var f in timeKeepingFeedback)
            {
                f.TimeOffRequestStateId = "003";
                _context.Update(f);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Deny(string id) // //id is a CheckinId 
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeKeepingFeedback = _context.TimeKeepingFeedbacks.Where(f => f.CheckinId == id);
            if (timeKeepingFeedback == null)
            {
                return NotFound();
            }
            foreach (var f in timeKeepingFeedback)
            {
                f.TimeOffRequestStateId = "002";
                _context.Update(f);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: TimeKeepingFeedbacks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeKeepingFeedback = await _context.TimeKeepingFeedbacks.FindAsync(id);
            if (timeKeepingFeedback == null)
            {
                return NotFound();
            }
            ViewData["CheckinId"] = new SelectList(_context.Checkins, "CheckinId", "CheckinId", timeKeepingFeedback.CheckinId);
            ViewData["TimeOffRequestStateId"] = new SelectList(_context.TimeOffRequestStates, "TimeOffRequestStateId", "TimeOffRequestStateId", timeKeepingFeedback.TimeOffRequestStateId);
            return View(timeKeepingFeedback);
        }

        // POST: TimeKeepingFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TimeKeepingFeedbackId,CheckinId,Reason,Time,TimeOffRequestStateId,Active")] TimeKeepingFeedback timeKeepingFeedback)
        {
            if (id != timeKeepingFeedback.TimeKeepingFeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeKeepingFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeKeepingFeedbackExists(timeKeepingFeedback.TimeKeepingFeedbackId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CheckinId"] = new SelectList(_context.Checkins, "CheckinId", "CheckinId", timeKeepingFeedback.CheckinId);
            ViewData["TimeOffRequestStateId"] = new SelectList(_context.TimeOffRequestStates, "TimeOffRequestStateId", "TimeOffRequestStateId", timeKeepingFeedback.TimeOffRequestStateId);
            return View(timeKeepingFeedback);
        }

        // GET: TimeKeepingFeedbacks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeKeepingFeedback = await _context.TimeKeepingFeedbacks
                .Include(t => t.Checkin)
                .Include(t => t.TimeOffRequestState)
                .FirstOrDefaultAsync(m => m.TimeKeepingFeedbackId == id);
            if (timeKeepingFeedback == null)
            {
                return NotFound();
            }

            return View(timeKeepingFeedback);
        }

        // POST: TimeKeepingFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var timeKeepingFeedback = await _context.TimeKeepingFeedbacks.FindAsync(id);
            _context.TimeKeepingFeedbacks.Remove(timeKeepingFeedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeKeepingFeedbackExists(string id)
        {
            return _context.TimeKeepingFeedbacks.Any(e => e.TimeKeepingFeedbackId == id);
        }
    }
}
