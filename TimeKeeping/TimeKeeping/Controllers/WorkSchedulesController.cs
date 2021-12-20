using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
            var timeKeepingDBContext = _context.WorkSchedules.Include(w => w.TypeWorkSchedule);
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
        public async Task<IActionResult> Create(WorkScheduleModel workScheduleModel)
        {
            // Using mapper to map model view to model db.
            WorkSchedule workSchedule = _mapper.Map<WorkSchedule>(workScheduleModel);

            // Id auto
            workSchedule.WorkScheduleId = _identityFactory.GenerateId(_context.WorkSchedules.Max(w => w.WorkScheduleId), "WS");

            if (ModelState.IsValid)
            {
                _context.Add(workSchedule);
                await _context.SaveChangesAsync();
                ViewBag.Message = "You have successfully create a work schedule";
                ViewBag.Status = "success";
                //Thread.Sleep(5000);
                //return RedirectToAction(nameof(Index));
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
