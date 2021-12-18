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

        // GET: TimeKeepingFeedbacks
        public async Task<IActionResult> Index()
        {
            var timeKeepingDBContext = _context.TimeKeepingFeedbacks.Include(t => t.Checkin);
            return View(await timeKeepingDBContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.TimeKeepingFeedbackId == id);
            if (timeKeepingFeedback == null)
            {
                return NotFound();
            }

            return View(timeKeepingFeedback);
        }

        // GET: TimeKeepingFeedbacks/Create
        [Route("TimeKeepingFeedbacks/Create/{CheckinId}")]
        public IActionResult Create(string CheckinId)
        {
           if (CheckinId == null)
            {
                return NotFound();
            }
            ViewData["CheckinId"] = new SelectList(_context.Checkins.Where(c => c.CheckinId== CheckinId), "CheckinId", "CheckinId");
            return View();
        }

        // POST: TimeKeepingFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TimeKeepingFeedbacks/Create/{CheckinId}")]
        public async Task<IActionResult> Create([Bind("TimeKeepingFeedbackId,CheckinId,Reason,Time")] TimeKeepingFeedback timeKeepingFeedback)
        {
            timeKeepingFeedback.Time = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(timeKeepingFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CheckinId"] = new SelectList(_context.Checkins, "CheckinId", "CheckinId", timeKeepingFeedback.CheckinId);
            return View(timeKeepingFeedback);
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
            return View(timeKeepingFeedback);
        }

        // POST: TimeKeepingFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TimeKeepingFeedbackId,CheckinId,Reason,Time")] TimeKeepingFeedback timeKeepingFeedback)
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
