using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping.Models;

namespace TimeKeeping.Controllers
{
    public class PersonnelApplyTimeOffPoliciesController : Controller
    {
        private readonly TimeKeepingDBContext _context;

        public PersonnelApplyTimeOffPoliciesController(TimeKeepingDBContext context)
        {
            _context = context;
        }

        public async Task UpdateDayPolicy()
        {
            if (DateTime.Now.Day == 1 && DateTime.Now.Month == 1)
            {
                var timeKeepingDBContext = _context.PersonnelApplyTimeOffPolicies.Include(p => p.Personnel).Include(p => p.TimeOffPolicy);
                var listPersonnels = await timeKeepingDBContext.ToListAsync();
                foreach (var personnel in listPersonnels)
                {
                    var personnelApplyTimeOffPolicy = await _context.TimeOffPolicies
                   .Include(p => p.TypePolicy)
                   .FirstOrDefaultAsync(m => m.TimeOffPolicyId == personnel.TimeOffPolicyId);
                    if (personnelApplyTimeOffPolicy != null)
                    {
                        personnel.NumberOfDaysOffStandard = (byte)(personnel.NumberOfDaysOffStandard + personnelApplyTimeOffPolicy.NumberOfDaysOffStandard);

                        try
                        {
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {

                        }
                    }
                }
            }
        }

        // GET: PersonnelApplyTimeOffPolicies
        public async Task<IActionResult> Index()
        {
            
            await UpdateDayPolicy();
            var timeKeepingDBContext = _context.PersonnelApplyTimeOffPolicies.Include(p => p.Personnel).Include(p => p.TimeOffPolicy);
            return View(await timeKeepingDBContext.ToListAsync());
        }

        // GET: PersonnelApplyTimeOffPolicies/Details/5
        [Route("[controller]/[action]/{personnalId}/{policyId}")]
        public async Task<IActionResult> Details(string personnalId, string policyId)
        {
            if (personnalId == null || policyId == null)
            {
                return NotFound();
            }

            var personnelApplyTimeOffPolicy = await _context.PersonnelApplyTimeOffPolicies
                .Include(p => p.Personnel)
                .Include(p => p.TimeOffPolicy)
                .FirstOrDefaultAsync(m => m.PersonnelId == personnalId && m.TimeOffPolicyId == policyId);
            if (personnelApplyTimeOffPolicy == null)
            {
                return NotFound();
            }

            return View(personnelApplyTimeOffPolicy);
        }

        // GET: PersonnelApplyTimeOffPolicies/Create
        public IActionResult Create()
        {
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId");
            ViewData["TimeOffPolicyId"] = new SelectList(_context.TimeOffPolicies, "TimeOffPolicyId", "TimeOffPolicyId");
            return View();
        }

        // POST: PersonnelApplyTimeOffPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonnelId,TimeOffPolicyId,EffectiveDate,NumberOfDaysOffLastYear,NumberOfDaysOffStandard,NumberOfDaysOffSeniority,NumberOfDaysOffOffset,Note,Del")] PersonnelApplyTimeOffPolicy personnelApplyTimeOffPolicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personnelApplyTimeOffPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId", personnelApplyTimeOffPolicy.PersonnelId);
            ViewData["TimeOffPolicyId"] = new SelectList(_context.TimeOffPolicies, "TimeOffPolicyId", "TimeOffPolicyId", personnelApplyTimeOffPolicy.TimeOffPolicyId);
            return View(personnelApplyTimeOffPolicy);
        }

        // GET: PersonnelApplyTimeOffPolicies/Edit/5
        [Route("[controller]/[action]/{personnalId}/{policyId}")]
        public async Task<IActionResult> Edit(string personnalId, string policyId)
        {
            if (personnalId == null || policyId == null)
            {
                return NotFound();
            }

            var personnelApplyTimeOffPolicy = await _context.PersonnelApplyTimeOffPolicies.FindAsync(personnalId, policyId);
            if (personnelApplyTimeOffPolicy == null)
            {
                return NotFound();
            }
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId", personnelApplyTimeOffPolicy.PersonnelId);
            ViewData["TimeOffPolicyId"] = new SelectList(_context.TimeOffPolicies, "TimeOffPolicyId", "TimeOffPolicyId", personnelApplyTimeOffPolicy.TimeOffPolicyId);
            return View(personnelApplyTimeOffPolicy);
        }

        // POST: PersonnelApplyTimeOffPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]/{personnalId}/{policyId}")]
        public async Task<IActionResult> Edit(string personnalId, string policyId, [Bind("PersonnelId,TimeOffPolicyId,EffectiveDate,NumberOfDaysOffLastYear,NumberOfDaysOffStandard,NumberOfDaysOffSeniority,NumberOfDaysOffOffset,Note,Del")] PersonnelApplyTimeOffPolicy personnelApplyTimeOffPolicy)
        {
            if (personnalId != personnelApplyTimeOffPolicy.PersonnelId || policyId != personnelApplyTimeOffPolicy.TimeOffPolicyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnelApplyTimeOffPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelApplyTimeOffPolicyExists(personnelApplyTimeOffPolicy.PersonnelId, personnelApplyTimeOffPolicy.TimeOffPolicyId))
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
            ViewData["PersonnelId"] = new SelectList(_context.Personnel, "PersonnelId", "PersonnelId", personnelApplyTimeOffPolicy.PersonnelId);
            ViewData["TimeOffPolicyId"] = new SelectList(_context.TimeOffPolicies, "TimeOffPolicyId", "TimeOffPolicyId", personnelApplyTimeOffPolicy.TimeOffPolicyId);
            return View(personnelApplyTimeOffPolicy);
        }

        // GET: PersonnelApplyTimeOffPolicies/Delete/5
        [Route("[controller]/[action]/{personnalId}/{policyId}")]
        public async Task<IActionResult> Delete(string personnalId, string policyId)
        {
            if (personnalId == null || policyId == null)
            {
                return NotFound();
            }

            var personnelApplyTimeOffPolicy = await _context.PersonnelApplyTimeOffPolicies
                .Include(p => p.Personnel)
                .Include(p => p.TimeOffPolicy)
                .FirstOrDefaultAsync(m => m.PersonnelId == personnalId && m.TimeOffPolicyId == policyId);
            if (personnelApplyTimeOffPolicy == null)
            {
                return NotFound();
            }

            return View(personnelApplyTimeOffPolicy);
        }

        // POST: PersonnelApplyTimeOffPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]/{personnalId}/{policyId}")]
        public async Task<IActionResult> DeleteConfirmed(string personnalId, string policyId)
        {
            var personnelApplyTimeOffPolicy = await _context.PersonnelApplyTimeOffPolicies.FindAsync(personnalId, policyId);
            _context.PersonnelApplyTimeOffPolicies.Remove(personnelApplyTimeOffPolicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Route("[controller]/[action]/{personnalId}/{policyId}")]
        private bool PersonnelApplyTimeOffPolicyExists(string personnalId, string policyId)
        {
            return _context.PersonnelApplyTimeOffPolicies.Any(e => e.PersonnelId == personnalId && e.TimeOffPolicyId == policyId);
        }
    }
}
