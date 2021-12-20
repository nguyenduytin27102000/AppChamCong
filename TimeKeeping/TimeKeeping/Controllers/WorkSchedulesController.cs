using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping.Models;
using TimeKeeping.Services;
using TimeKeeping.ViewModels;

namespace TimeKeeping.Controllers
{
    public class WorkSchedulesController : Controller
    {
        private readonly TimeKeepingDBContext _context;
        private readonly IMapper _mapper;
        private readonly IdentityFactory _identityFactory;

        public WorkSchedulesController(TimeKeepingDBContext context, IMapper mapper, IdentityFactory identityFactory)
        {
            _context = context;
            _mapper = mapper;
            _identityFactory = identityFactory;
        }

        // GET: WorkSchedules
        public async Task<IActionResult> Index()
        {
            //var workSchedules = _context.WorkSchedules.Include(w => w.TypeWorkSchedule);

            var workSchedules = from w in _context.WorkSchedules
                                select w;

            workSchedules = workSchedules.Include(w => w.TypeWorkSchedule);
            workSchedules = workSchedules.OrderByDescending(w => w.Del);


            return View(await workSchedules.ToListAsync());
        }

        // GET: WorkSchedules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules
                .Include(w => w.TypeWorkSchedule)
                .Include(w => w.Shifts)
                .ThenInclude(s => s.DaysOfWeek)
                .FirstOrDefaultAsync(m => m.WorkScheduleId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            return View(workSchedule);
        }

        // GET: WorkSchedules/Create
        public IActionResult Create()
        {
            ViewData["TypeWorkScheduleId"] = new SelectList(_context.TypeWorkSchedules, "TypeWorkScheduleId", "TypeWorkScheduleName");
            return View();
        }

        // POST: WorkSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkScheduleModel workScheduleModel, IFormCollection fields)
        {
            // Using mapper to map model view to model db.
            WorkSchedule workSchedule = _mapper.Map<WorkSchedule>(workScheduleModel);
            workSchedule.TypeWorkScheduleId = fields["duration"];


            if (workSchedule.StartDay == null && workSchedule.EndDay == null)
            {
                workSchedule.StartDay = DateTime.Now;
            }

            // Id auto.
            workSchedule.WorkScheduleId = _identityFactory.GenerateId(_context.WorkSchedules.Max(w => w.WorkScheduleId), "WS");

            // Use for create new shift.
            var shift = new Shift();

            // Day of week checked.
            string[] dayOfWeek =
            {
                fields["monday"],
                fields["tuesday"],
                fields["wednesday"],
                fields["thurday"],
                fields["friday"],
                fields["saturday"],
                fields["sunday"],
            };

            // Use for day of week id.
            string[] index = { "1", "2", "3", "4", "5", "6", "7" };

            // haft-day
            string[] halfDay =
            {
                fields["monday-half"],
                fields["tuesday-half"],
                fields["wednesday-half"],
                fields["thursday-half"],
                fields["friday-half"],
                fields["saturday-half"],
                fields["sunday-half"]
            };

            // spectify
            string[] startHour =
            {
                fields["start-hour-monday"],
                fields["start-hour-tuesday"],
                fields["start-hour-wednesday"],
                fields["start-hour-thurday"],
                fields["start-hour-friday"],
                fields["start-hour-saturday"],
                fields["start-hour-sunday"]
            };

            string[] endHour =
            {
                fields["end-hour-monday"],
                fields["end-hour-tuesday"],
                fields["end-hour-wednesday"],
                fields["end-hour-thurday"],
                fields["end-hour-friday"],
                fields["end-hour-saturday"],
                fields["end-hour-sunday"]
            };

            if (ModelState.IsValid)
            {
                _context.Add(workSchedule);
                await _context.SaveChangesAsync();

                if (String.Compare(fields["duration"], "1") == 0)
                {
                    for (int i = 0; i < dayOfWeek.Length; i++)
                    {
                        if (dayOfWeek[i] != null)
                        {
                            shift.WorkScheduleId = workSchedule.WorkScheduleId;
                            shift.DaysOfWeekId = index[i];
                            shift.ShiftId = $"{workSchedule.WorkScheduleId[8]}{workSchedule.WorkScheduleId[9]}-{index[i]}";
                            shift.ShiftName = "Full-time";
                            shift.StartTime = new DateTime(1753, 1, 1, 8, 0, 0);
                            shift.EndTime = new DateTime(1753, 1, 1, 18, 0, 0);
                            _context.Add(shift);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else if (String.Compare(fields["duration"], "2") == 0)
                {
                    for (int i = 0; i < dayOfWeek.Length; i++)
                    {
                        if (dayOfWeek[i] != null)
                        {
                            shift.WorkScheduleId = workSchedule.WorkScheduleId;
                            shift.DaysOfWeekId = index[i];
                            shift.ShiftId = $"{workSchedule.WorkScheduleId[8]}{workSchedule.WorkScheduleId[9]}-{index[i]}";

                            if (String.Compare(halfDay[i], "1") == 0)
                            {
                                shift.ShiftName = "Morning";
                                shift.StartTime = new DateTime(1753, 1, 1, 8, 0, 0);
                                shift.EndTime = new DateTime(1753, 1, 1, 12, 0, 0);
                            }
                            else
                            {
                                shift.ShiftName = "Afternoon";
                                shift.StartTime = new DateTime(1753, 1, 1, 14, 0, 0);
                                shift.EndTime = new DateTime(1753, 1, 1, 18, 0, 0);
                            }

                            _context.Add(shift);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else if (String.Compare(fields["duration"], "3") == 0)
                {
                    for (int i = 0; i < dayOfWeek.Length; i++)
                    {
                        if (dayOfWeek[i] != null)
                        {
                            shift.WorkScheduleId = workSchedule.WorkScheduleId;
                            shift.DaysOfWeekId = index[i];
                            shift.ShiftId = $"{workSchedule.WorkScheduleId[8]}{workSchedule.WorkScheduleId[9]}-{index[i]}";
                            shift.ShiftName = "Spectify";
                            shift.StartTime = DateTime.Parse(startHour[i]);
                            shift.EndTime = DateTime.Parse(endHour[i]);
                            _context.Add(shift);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                ViewBag.Message = "You have successfully create a work schedule";
                ViewBag.Status = "success";
                return View();
            }
            ViewData["TypeWorkScheduleId"] = new SelectList(_context.TypeWorkSchedules, "TypeWorkScheduleId", "TypeWorkScheduleName", workSchedule.TypeWorkScheduleId);
            return View(workSchedule);
        }

        // GET: WorkSchedules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules.FindAsync(id);
            if (workSchedule == null)
            {
                return NotFound();
            }
            ViewData["TypeWorkScheduleId"] = new SelectList(_context.TypeWorkSchedules, "TypeWorkScheduleId", "TypeWorkScheduleId", workSchedule.TypeWorkScheduleId);
            return View(workSchedule);
        }

        // POST: WorkSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WorkScheduleId,WorkScheduleName,TypeWorkScheduleId,CheckinPolicyId,NumberOfShiftId,RequireCheckout,WorkingHoursPerDay,MinutesLate,MinutesEarly,Regulations,States,Del")] WorkSchedule workSchedule)
        {
            if (id != workSchedule.WorkScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkScheduleExists(workSchedule.WorkScheduleId))
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
            ViewData["TypeWorkScheduleId"] = new SelectList(_context.TypeWorkSchedules, "TypeWorkScheduleId", "TypeWorkScheduleId", workSchedule.TypeWorkScheduleId);
            return View(workSchedule);
        }

        // GET: WorkSchedules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules
                .Include(w => w.TypeWorkSchedule)
                .FirstOrDefaultAsync(m => m.WorkScheduleId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            workSchedule.Del = false;
            _context.Update(workSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: WorkSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var workSchedule = await _context.WorkSchedules.FindAsync(id);
            _context.WorkSchedules.Remove(workSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkScheduleExists(string id)
        {
            return _context.WorkSchedules.Any(e => e.WorkScheduleId == id);
        }

        // GET: WorkSchedules/Restore/5
        public async Task<IActionResult> Restore(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules
                .Include(w => w.TypeWorkSchedule)
                .FirstOrDefaultAsync(m => m.WorkScheduleId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            workSchedule.Del = true;
            _context.Update(workSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
