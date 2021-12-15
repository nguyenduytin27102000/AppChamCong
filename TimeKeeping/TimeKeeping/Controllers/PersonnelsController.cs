using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping.Models;
using TimeKeeping.ViewModels;
using TimeKeeping.ViewModels.Personnels;

namespace TimeKeeping.Controllers
{
    public class PersonnelsController : Controller
    {
        private readonly TimeKeepingDBContext _context;
        private readonly IMapper _mapper;

        public PersonnelsController(TimeKeepingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Personnels
        public async Task<IActionResult> Index()
        {
            var timeKeepingDBContext = _context.Personnel.Include(p => p.Office).Include(p => p.Position).Include(p => p.SalaryPolicy).Include(p => p.TypePersonnel).Include(p => p.WorkSchedule).Include(p => p.WorkingArea);
            return View(await timeKeepingDBContext.ToListAsync());
        }

        // GET: Personnels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var personnel = await _context.Personnel
                .FirstOrDefaultAsync(m => m.PersonnelId == id);

            var personnelDetailModel = _mapper.Map<PersonnelDetailModel>(personnel);
            if (personnel == null)
            {
                return NotFound();
            }

            return View(personnelDetailModel);
        }

        // GET: Personnels/Create
        public IActionResult Create()
        {
            ViewData["OfficeId"] = new SelectList(_context.Offices, "OfficeId", "OfficeName");
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName");
            ViewData["SalaryPolicyId"] = new SelectList(_context.SalaryPolicies, "SalaryPolicyId", "SalaryPolicyName");
            ViewData["TypePersonnelId"] = new SelectList(_context.TypePersonnel, "TypePersonnelId", "TypePersonnelName");
            ViewData["WorkScheduleId"] = new SelectList(_context.WorkSchedules, "WorkScheduleId", "WorkScheduleName");
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "WorkingAreaId", "WorkingAreaName");
            return View();
        }

        // POST: Personnels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonnelId,FirstName,LastName,Email,OfficeId,WorkScheduleId,WorkingAreaId,PositionId,SalaryPolicyId,TypePersonnelId,Title,ActualSalary,BasicSalary,StartDate,OfficialDate,DateOfBirth,Phone,Sex,PersonnelAddress,Del")] Personnel personnel)
        {
            var listPersonnel = _context.Personnel.ToList();

            // If Id is exict in database, then alert.
            foreach (var oldPersonnel in listPersonnel)
            {
                if (personnel.PersonnelId == oldPersonnel.PersonnelId)
                {
                    ModelState.AddModelError("", "This ID is exict in list!");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(personnel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "OfficeId", "OfficeName", personnel.OfficeId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", personnel.PositionId);
            ViewData["SalaryPolicyId"] = new SelectList(_context.SalaryPolicies, "SalaryPolicyId", "SalaryPolicyName", personnel.SalaryPolicyId);
            ViewData["TypePersonnelId"] = new SelectList(_context.TypePersonnel, "TypePersonnelId", "TypePersonnelName", personnel.TypePersonnelId);
            ViewData["WorkScheduleId"] = new SelectList(_context.WorkSchedules, "WorkScheduleId", "WorkScheduleName", personnel.WorkScheduleId);
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "WorkingAreaId", "WorkingAreaName", personnel.WorkingAreaId);
            return View(personnel);
        }

        // GET: Personnels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            // If id doesn't exist, then return not found.
            if (id == null)
            {
                return NotFound();
            }

            // Find personnel in data by id.
            var personnel = await _context.Personnel.FindAsync(id);

            // If this personnel doesn't exist, then return not found.
            if (personnel == null)
            {
                return NotFound();
            }

            // Use ViewData to save a select list from other table.
            ViewData["OfficeId"] = new SelectList(_context.Offices, "OfficeId", "OfficeName", personnel.OfficeId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", personnel.PositionId);
            ViewData["SalaryPolicyId"] = new SelectList(_context.SalaryPolicies, "SalaryPolicyId", "SalaryPolicyName", personnel.SalaryPolicyId);
            ViewData["TypePersonnelId"] = new SelectList(_context.TypePersonnel, "TypePersonnelId", "TypePersonnelName", personnel.TypePersonnelId);
            ViewData["WorkScheduleId"] = new SelectList(_context.WorkSchedules, "WorkScheduleId", "WorkScheduleName", personnel.WorkScheduleId);
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "WorkingAreaId", "WorkingAreaName", personnel.WorkingAreaId);

            // List delete state of this personnel.
            //var deleteSate = new Dictionary<bool, string>()
            //{
            //    {true, "Using" },
            //    {false, "Don't use"}
            //};

            // Use ViewBag save list of delete state use for view.
            //ViewBag.DeleteSate = new SelectList(deleteSate, "Key", "Value");

            return View(personnel);
        }

        // POST: Personnels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonnelId,FirstName,LastName,Email,OfficeId,WorkScheduleId,WorkingAreaId,PositionId,SalaryPolicyId,TypePersonnelId,Title,ActualSalary,BasicSalary,StartDate,OfficialDate,DateOfBirth,Phone,Sex,PersonnelAddress,Del")] Personnel personnel)
        {
            if (id != personnel.PersonnelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelExists(personnel.PersonnelId))
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
            ViewData["OfficeId"] = new SelectList(_context.Offices, "OfficeId", "OfficeId", personnel.OfficeId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", personnel.PositionId);
            ViewData["SalaryPolicyId"] = new SelectList(_context.SalaryPolicies, "SalaryPolicyId", "SalaryPolicyName", personnel.SalaryPolicyId);
            ViewData["TypePersonnelId"] = new SelectList(_context.TypePersonnel, "TypePersonnelId", "TypePersonnelName", personnel.TypePersonnelId);
            ViewData["WorkScheduleId"] = new SelectList(_context.WorkSchedules, "WorkScheduleId", "WorkScheduleName", personnel.WorkScheduleId);
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "WorkingAreaId", "WorkingAreaName", personnel.WorkingAreaId);
            return View(personnel);
        }

        // GET: Personnels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnel
                .Include(p => p.Office)
                .Include(p => p.Position)
                .Include(p => p.SalaryPolicy)
                .Include(p => p.TypePersonnel)
                .Include(p => p.WorkSchedule)
                .Include(p => p.WorkingArea)
                .FirstOrDefaultAsync(m => m.PersonnelId == id);
            if (personnel == null)
            {
                return NotFound();
            }

            personnel.Del = false;
            _context.Update(personnel);
            UpdateDeleteStateFromOtherTable(id, false);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Personnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personnel = await _context.Personnel.FindAsync(id);
            _context.Personnel.Remove(personnel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonnelExists(string id)
        {
            return _context.Personnel.Any(e => e.PersonnelId == id);
        }

        // GET: Personnels/Restore/5
        public async Task<IActionResult> Restore(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnel
                .Include(p => p.Office)
                .Include(p => p.Position)
                .Include(p => p.SalaryPolicy)
                .Include(p => p.TypePersonnel)
                .Include(p => p.WorkSchedule)
                .Include(p => p.WorkingArea)
                .FirstOrDefaultAsync(m => m.PersonnelId == id);
            if (personnel == null)
            {
                return NotFound();
            }

            personnel.Del = true;
            _context.Update(personnel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // If delete state of this personnel change
        // all table use this id of personnel will change.
        // So function use for this.
        public void UpdateDeleteStateFromOtherTable(string id, bool deleteSateOfPersonnel)
        {
            // Find all data row from personnel apply time off policie table.
            var applyTimeOffPolicys = _context.PersonnelApplyTimeOffPolicies.Where(a => a.PersonnelId == id).ToList();
            foreach (var applyTimeOffPolicy in applyTimeOffPolicys)
            {
                applyTimeOffPolicy.Del = deleteSateOfPersonnel;
                _context.Update(applyTimeOffPolicy);
            }

            // Find all data row from time off approvers table.
            var timeOffApprovers = _context.TimeOffApprovers.Where(toa => toa.PersonnelId == id).ToList();
            foreach (var timeOffApprover in timeOffApprovers)
            {
                timeOffApprover.Del = deleteSateOfPersonnel;
                _context.Update(timeOffApprover);
            }

            // Find all data row from time off followers table.
            var timeOffFollowers = _context.TimeOffFollowers.Where(tof => tof.PersonnelId == id).ToList();
            foreach (var timeOffFollower in timeOffFollowers)
            {
                timeOffFollower.Del = deleteSateOfPersonnel;
                _context.Update(timeOffFollower);
            }

            // Find all data row from time off requests table.
            var timeOffRequestPersonnels = _context.TimeOffRequests.Where(tofp => tofp.PersonnelId == id).ToList();
            foreach (var timeOffRequestPersonnel in timeOffRequestPersonnels)
            {
                timeOffRequestPersonnel.Del = deleteSateOfPersonnel;
                _context.Update(timeOffRequestPersonnel);
            }
        }
    }
}
