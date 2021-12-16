using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping.Models;
using TimeKeeping.ViewModels;

namespace TimeKeeping.Controllers
{
    public class WorkSchedulesController : Controller
    {
        private readonly TimeKeepingDBContext _context;
        private readonly IMapper _mapper;

        public WorkSchedulesController(TimeKeepingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: WorkSchedules
        public async Task<IActionResult> Index()
        {
            var timeKeepingDBContext = _context.WorkSchedules.Include(w => w.CheckinPolicy).Include(w => w.NumberOfShift).Include(w => w.TypeWorkSchedule);
            return View(await timeKeepingDBContext.ToListAsync());
        }

        // GET: WorkSchedules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedules
                .Include(w => w.CheckinPolicy)
                .Include(w => w.NumberOfShift)
                .Include(w => w.TypeWorkSchedule)
                .FirstOrDefaultAsync(m => m.WorkScheduleId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            ViewData["TypeShifts"] = new SelectList(_context.TypeShifts, "TypeShiftId", "TypeShiftName");
            return View(workSchedule);
        }

        // GET: WorkSchedules/Create
        public IActionResult Create()
        {
            ViewData["CheckinPolicyId"] = new SelectList(_context.CheckinPolicies, "CheckinPolicyId", "CheckinPolicyName");
            ViewData["NumberOfShiftId"] = new SelectList(_context.NumberOfShifts, "NumberOfShiftId", "Count");
            ViewData["TypeWorkScheduleId"] = new SelectList(_context.TypeWorkSchedules, "TypeWorkScheduleId", "TypeWorkScheduleName");
            return View();
        }

        // POST: WorkSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Create(WorkScheduleModel workScheduleModel)
        {
            // Using mapper to map model view to model db.
            WorkSchedule workSchedule = _mapper.Map<WorkSchedule>(workScheduleModel);

            if (ModelState.IsValid)
            {
                _context.Add(workSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CheckinPolicyId"] = new SelectList(_context.CheckinPolicies, "CheckinPolicyId", "CheckinPolicyName", workSchedule.CheckinPolicyId);
            ViewData["NumberOfShiftId"] = new SelectList(_context.NumberOfShifts, "NumberOfShiftId", "Count", workSchedule.NumberOfShiftId);
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
            ViewData["CheckinPolicyId"] = new SelectList(_context.CheckinPolicies, "CheckinPolicyId", "CheckinPolicyId", workSchedule.CheckinPolicyId);
            ViewData["NumberOfShiftId"] = new SelectList(_context.NumberOfShifts, "NumberOfShiftId", "NumberOfShiftId", workSchedule.NumberOfShiftId);
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
            ViewData["CheckinPolicyId"] = new SelectList(_context.CheckinPolicies, "CheckinPolicyId", "CheckinPolicyId", workSchedule.CheckinPolicyId);
            ViewData["NumberOfShiftId"] = new SelectList(_context.NumberOfShifts, "NumberOfShiftId", "NumberOfShiftId", workSchedule.NumberOfShiftId);
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
                .Include(w => w.CheckinPolicy)
                .Include(w => w.NumberOfShift)
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
                .Include(w => w.CheckinPolicy)
                .Include(w => w.NumberOfShift)
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
