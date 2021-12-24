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
    public class TimeOffPoliciesController : Controller
    {
        private readonly TimeKeepingDBContext _context;

        public TimeOffPoliciesController(TimeKeepingDBContext context)
        {
            _context = context;
        }

        // GET: TimeOffPolicies
        public async Task<IActionResult> Index(string sortOrder,
                                               string name,
                                               string type)
        {
            // Get list timeoff policy in database for display.
            var timeOffPolicies = from t in _context.TimeOffPolicies
                                  select t;

            // Search.
            ViewData["Name"] = name;
            ViewData["TypePolicyId"] = new SelectList(_context.TypePolicies, "TypePolicyId", "TypePolicyName", type);

            if (!String.IsNullOrEmpty(name))
            {
                timeOffPolicies = timeOffPolicies.Where(t => t.TimeOffPolicyName.Contains(name));
            }

            if (!String.IsNullOrEmpty(type))
            {
                timeOffPolicies = timeOffPolicies.Where(t => t.TypePolicyId == type);
            }

            // Sorted.
            ViewData["ActiveParm"] = String.IsNullOrEmpty(sortOrder) ? "active" : "";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";

            switch (sortOrder)
            {
                case "name":
                    timeOffPolicies = timeOffPolicies.OrderBy(t => t.TimeOffPolicyName);
                    break;
                case "name_desc":
                    timeOffPolicies = timeOffPolicies.OrderByDescending(t => t.TimeOffPolicyName);
                    break;
                case "active":
                    timeOffPolicies = timeOffPolicies.OrderBy(t => t.Active);
                    break;
                default:
                    timeOffPolicies = timeOffPolicies.OrderByDescending(t => t.Active);
                    break;
            }

            // Pass arguments for index view.
            // After that index will display data.
            return View(await timeOffPolicies.ToListAsync());
        }

        // GET: TimeOffPolicies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            // If id doen't exist display not found.
            if (id == null)
            {
                return NotFound();
            }

            // Uses the FirstOrDefaultAsync method to retrieve a single TimeoffPolicy entity.
            // Include methods cause the context to load the TimeOffPolicies.TimeOffPolicyId property.
            var timeOffPolicy = await _context.TimeOffPolicies
                .Include(t => t.TypePolicy)
                .FirstOrDefaultAsync(m => m.TimeOffPolicyId == id);

            // If this timeoff policy doesn't exist display not found.
            if (timeOffPolicy == null)
            {
                return NotFound();
            }

            // Pass argument for detail view.
            return View(timeOffPolicy);
        }

        // GET: TimeOffPolicies/Create
        public IActionResult Create()
        {
            // Save a list type of policy through ViewData
            // then use for create view.
            ViewData["TypePolicyId"] = new SelectList(_context.TypePolicies, "TypePolicyId", "TypePolicyName");
            return View();
        }

        // POST: TimeOffPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeOffPolicyId,TimeOffPolicyName,TypePolicyId,NumberOfDaysOffStandard,NumberOfDaysOffLastYear,Describe,Del")] TimeOffPolicy timeOffPolicy)
        {
            var listTimeoffPolicies = _context.TimeOffPolicies.ToList();

            // If Id is exict in database, then alert.
            foreach (var oldTimeOffPolicy in listTimeoffPolicies)
            {
                if (timeOffPolicy.TimeOffPolicyId == oldTimeOffPolicy.TimeOffPolicyId)
                {
                    ModelState.AddModelError("", "This ID is exict in list!");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(timeOffPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypePolicyId"] = new SelectList(_context.TypePolicies, "TypePolicyId", "TypePolicyName", timeOffPolicy.TypePolicyId);
            return View(timeOffPolicy);
        }

        // GET: TimeOffPolicies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            // If this id doesn't exict, display not found.
            if (id == null)
            {
                return NotFound();
            }

            // Find a timeoff policy in data.
            var timeOffPolicy = await _context.TimeOffPolicies.FindAsync(id);

            // If this policy doesn't exict, then display not found.
            if (timeOffPolicy == null)
            {
                return NotFound();
            }

            // Save list typeOfPolicyID though ViewData use for view.
            ViewData["TypePolicyId"] = new SelectList(_context.TypePolicies, "TypePolicyId", "TypePolicyId", timeOffPolicy.TypePolicyId);

            // List state of timeoff policy.
            var deleteSate = new Dictionary<bool, string>()
            {
                {true, "Using" },
                {false, "Don't use"}
            };

            // Use ViewBag save list of delete state use for view.
            ViewBag.DeleteSate = new SelectList(deleteSate, "Key", "Value");
            return View(timeOffPolicy);
        }

        // POST: TimeOffPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TimeOffPolicyId,TimeOffPolicyName,TypePolicyId,NumberOfDaysOffStandard,NumberOfDaysOffLastYear,Describe,Del")] TimeOffPolicy timeOffPolicy)
        {
            // If this time off policy doesn't exict, then display not found.
            if (id != timeOffPolicy.TimeOffPolicyId)
            {
                return NotFound();
            }

            // If this time off policy exict, then update this.
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeOffPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeOffPolicyExists(timeOffPolicy.TimeOffPolicyId))
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
            ViewData["TypePolicyId"] = new SelectList(_context.TypePolicies, "TypePolicyId", "TypePolicyId", timeOffPolicy.TypePolicyId);
            return View(timeOffPolicy);
        }

        // GET: TimeOffPolicies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            // If this id doesn't exict, then display not found.
            if (id == null)
            {
                return NotFound();
            }

            var timeOffPolicy = await _context.TimeOffPolicies
                .Include(t => t.TypePolicy)
                .FirstOrDefaultAsync(m => m.TimeOffPolicyId == id);

            // If this timeoff policy doesn't exict, then display not found.
            if (timeOffPolicy == null)
            {
                return NotFound();
            }

            timeOffPolicy.Active = false;
            _context.Update(timeOffPolicy);
            await _context.SaveChangesAsync();

            // Pass argument for view to display information of this timeoff policy.
            return RedirectToAction(nameof(Index));
        }

        // POST: TimeOffPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var timeOffPolicy = await _context.TimeOffPolicies.FindAsync(id);
            _context.TimeOffPolicies.Remove(timeOffPolicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeOffPolicyExists(string id)
        {
            return _context.TimeOffPolicies.Any(e => e.TimeOffPolicyId == id);
        }

        // GET: TimeOffPolicies/Retore/5
        public async Task<IActionResult> Restore(string id)
        {
            // If this id doesn't exict, then display not found.
            if (id == null)
            {
                return NotFound();
            }

            var timeOffPolicy = await _context.TimeOffPolicies
                .Include(t => t.TypePolicy)
                .FirstOrDefaultAsync(m => m.TimeOffPolicyId == id);

            // If this timeoff policy doesn't exict, then display not found.
            if (timeOffPolicy == null)
            {
                return NotFound();
            }

            timeOffPolicy.Active = true;
            _context.Update(timeOffPolicy);
            await _context.SaveChangesAsync();

            // Pass argument for view to display information of this timeoff policy.
            return RedirectToAction(nameof(Index));
        }
    }
}
