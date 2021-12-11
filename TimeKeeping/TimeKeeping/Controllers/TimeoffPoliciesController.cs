using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping.Models;

namespace TimeKeeping.Controllers
{
    public class TimeoffPoliciesController : Controller
    {
        private readonly TimekeepingContext _context;

        public TimeoffPoliciesController(TimekeepingContext context)
        {
            _context = context;
        }

        // GET: TimeoffPolicys
        public async Task<IActionResult> Index()
        {
            // Get list timeoff policy in database for display.
            var timekeepingContext = _context.ChinhSachNghiPheps.Include(c => c.MaLoaiChinhSachNavigation);

            // Pass arguments for index view.
            // After that index will display data.
            return View(await timekeepingContext.ToListAsync());
        }

        // GET: TimeoffPolicys/Details/5
        public async Task<IActionResult> Details(string id)
        {
            // If id doen't exist display not found.
            if (id == null)
            {
                return NotFound();
            }

            // Uses the FirstOrDefaultAsync method to retrieve a single TimeoffPolicy entity.
            // Include methods cause the context to load the ChinhSachNghiPheps. LoaiChinhSach property.
            var timeoffPolicys = await _context.ChinhSachNghiPheps
                .Include(c => c.MaLoaiChinhSachNavigation)
                .FirstOrDefaultAsync(m => m.MaChinhSachNghiPhep == id);

            // If this timeoff policy doesn't exist display not found.
            if (timeoffPolicys == null)
            {
                return NotFound();
            }

            // Pass argument for detail view.
            return View(timeoffPolicys);
        }

        // GET: TimeoffPolicys/Create
        public IActionResult Create()
        {
            // Save a list type of policy through ViewData
            // then use for create view.
            ViewData["TypeOfPolicyID"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "TenLoaiChinhSach");
            return View();
        }

        // POST: TimeoffPolicys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChinhSachNghiPhep,TenChinhSach,MaLoaiChinhSach,SoLuongPhepChuanNam,SoLuongPhepTon,MoTa,Xoa")] ChinhSachNghiPhep timeOffPolicy)
        {
            var listTimeoffPolicys = _context.ChinhSachNghiPheps.ToList();

            // If Id is exict in database, then alert.
            foreach (var oldTimeOffPolics in listTimeoffPolicys)
            {
                if (timeOffPolicy.MaChinhSachNghiPhep == oldTimeOffPolics.MaChinhSachNghiPhep)
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
            ViewData["TypeOfPolicyID"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "MaLoaiChinhSach", timeOffPolicy.MaLoaiChinhSach);
            return View(timeOffPolicy);
        }

        // GET: TimeoffPolicys/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            // List state of timeoff policy.
            var deleteSate = new Dictionary<bool, string>()
            {
                {true, "Using" },
                {false, "Don't use"}
            };

            // If this id doesn't exict, display not found.
            if (id == null)
            {
                return NotFound();
            }

            // Find a timeoff policy in data.
            var timeOffPolicy = await _context.ChinhSachNghiPheps.FindAsync(id);

            // If this policy don't exict, then display not found.
            if (timeOffPolicy == null)
            {
                return NotFound();
            }
            
            // Save list typeOfPolicyID though ViewData use for view.
            ViewData["typeOfPolicyID"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "TenLoaiChinhSach", timeOffPolicy.MaLoaiChinhSach);

            // Use ViewBag save list of delete state use for view.
            ViewBag.DeleteSate = new SelectList(deleteSate, "Key", "Value");

            return View(timeOffPolicy);
        }

        // POST: TimeoffPolicys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChinhSachNghiPhep,TenChinhSach,MaLoaiChinhSach,SoLuongPhepChuanNam,SoLuongPhepTon,MoTa,Xoa")] ChinhSachNghiPhep timeOffPolicy)
        {
            // If this time off policy doesn't exict, then display not found.
            if (id != timeOffPolicy.MaChinhSachNghiPhep)
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
                    if (!ChinhSachNghiPhepExists(timeOffPolicy.MaChinhSachNghiPhep))
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
            ViewData["TypeOfPolicyID"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "MaLoaiChinhSach", timeOffPolicy.MaLoaiChinhSach);
            return View(timeOffPolicy);
        }

        // GET: TimeoffPolicys/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            // If this id doesn't exict, then display not found.
            if (id == null)
            {
                return NotFound();
            }

            var timeOffPolicy = await _context.ChinhSachNghiPheps
                .Include(c => c.MaLoaiChinhSachNavigation)
                .FirstOrDefaultAsync(m => m.MaChinhSachNghiPhep == id);

            // If this timeoff policy doesn't exict, then display not found.
            if (timeOffPolicy == null)
            {
                return NotFound();
            }

            // Pass argument for view to display information of this timeoff policy.
            return View(timeOffPolicy);
        }

        // POST: TimeoffPolicys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var timeOffPolicy = await _context.ChinhSachNghiPheps.FindAsync(id);
            _context.ChinhSachNghiPheps.Remove(timeOffPolicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChinhSachNghiPhepExists(string id)
        {
            return _context.ChinhSachNghiPheps.Any(e => e.MaChinhSachNghiPhep == id);
        }
    }
}
