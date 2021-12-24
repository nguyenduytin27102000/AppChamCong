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
    public class CheckinsController : Controller
    {
        private readonly TimeKeepingDBContext _context;

        public CheckinsController(TimeKeepingDBContext context)
        {
            _context = context;
        }

        // GET: Checkins
    // view checkin (same meaning personnal timesheet) but it hasn't check user and role yet.
    // i mean identity. account user role.
    // id is a id an employee
        public async Task<IActionResult> Index(string id,int month,int year)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (month == 0)
                month = DateTime.Now.Month;
            if( year == 0)
                year = DateTime.Now.Year;
            ViewBag.Month = month;
            ViewBag.Year = year;
            ViewBag.Id = id;
            var timeKeepingDBContext = _context.Checkins.Include(c => c.Personnel);
            var per = (from c in _context.Checkins
                       join p in _context.Personnel on c.PersonnelId equals p.PersonnelId
                       join w in _context.WorkSchedules on p.WorkScheduleId equals w.WorkScheduleId
                       join s in _context.Shifts on w.WorkScheduleId equals s.WorkScheduleId
                       // 6 is 6:00 AM. It is used to determine Morning or Evening 
                       where ((s.StartTime.Hour - 6 <= 5 && c.Time.Hour - 6 <=5) || (s.EndTime.Hour - 6 > 5 && c.Time.Hour - 6 > 5))  && (c.PersonnelId == id && c.Time.Month == month && c.Time.Year == year && c.Active == true)
                       select new CheckinWithView
                       {
                           CheckinId = c.CheckinId,
                           Time = c.Time,
                           Personnal = p.LastName,
                           WorkScheduleName = w.WorkScheduleName,
                           MinutesLate = w.MinutesLate,
                           MinutesEarly = w.MinutesEarly,
                           Regulations = w.Regulations,
                           StartTime = s.StartTime,
                           DayOff = s.DayOff,
                           EndTime = s.EndTime,
                       });
          
            return View(per.ToList());
            
        }
       
        // GET: Checkins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkin = await _context.Checkins
                .Include(c => c.Personnel)
                .FirstOrDefaultAsync(m => m.CheckinId == id);
            if (checkin == null)
            {
                return NotFound();
            }

            return View(checkin);
        }

        // GET: Checkins/Create
        public IActionResult Create()
        {
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId");
            return View();
        }

        // POST: Checkins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckinId,PersonnelId,Time")] Checkin checkin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId", checkin.PersonnelId);
            return View(checkin);
        }

        // GET: Checkins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkin = await _context.Checkins.FindAsync(id);
            if (checkin == null)
            {
                return NotFound();
            }
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId", checkin.PersonnelId);
            return View(checkin);
        }

        // POST: Checkins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CheckinId,PersonnelId,Time")] Checkin checkin)
        {
            if (id != checkin.CheckinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckinExists(checkin.CheckinId))
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
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId", checkin.PersonnelId);
            return View(checkin);
        }

        // GET: Checkins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkin = await _context.Checkins
                .Include(c => c.Personnel)
                .FirstOrDefaultAsync(m => m.CheckinId == id);
            if (checkin == null)
            {
                return NotFound();
            }

            return View(checkin);
        }

        // POST: Checkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var checkin = await _context.Checkins.FindAsync(id);
            _context.Checkins.Remove(checkin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckinExists(string id)
        {
            return _context.Checkins.Any(e => e.CheckinId == id);
        }
    }
}
