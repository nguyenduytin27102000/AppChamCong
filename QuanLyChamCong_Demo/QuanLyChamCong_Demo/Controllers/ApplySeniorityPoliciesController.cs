using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping_Demo.Models;

namespace TimeKeeping_Demo.Controllers
{
    public class ApplySeniorityPoliciesController : Controller
    {
        private readonly TimekeepingContext _context;

        public ApplySeniorityPoliciesController(TimekeepingContext context)
        {
            _context = context;
        }

        // GET: ApplySeniorityPolicies
        public async Task<IActionResult> Index()
        {
            var timekeepingContext = _context.ApDungThamNiens.Include(a => a.MaChinhSachNghiPhepNavigation).Include(a => a.MaThamNienNavigation);
            return View(await timekeepingContext.ToListAsync());
        }

        // GET: ApplySeniorityPolicies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applySeniority = await _context.ApDungThamNiens
                .Include(a => a.MaChinhSachNghiPhepNavigation)
                .Include(a => a.MaThamNienNavigation)
                .FirstOrDefaultAsync(m => m.MaChinhSachNghiPhep == id);
            if (applySeniority == null)
            {
                return NotFound();
            }

            return View(applySeniority);
        }

        // GET: ApplySeniorityPolicies/Create
        public IActionResult Create()
        {
            ViewData["MaChinhSachNghiPhep"] = new SelectList(_context.ChinhSachNghiPheps, "MaChinhSachNghiPhep", "MaChinhSachNghiPhep");
            ViewData["MaThamNien"] = new SelectList(_context.ChinhSachTheoThamNiens, "MaThamNien", "MaThamNien");
            return View();
        }

        // POST: ApDungThamNiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChinhSachNghiPhep,MaThamNien")] ApDungThamNien apDungThamNien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apDungThamNien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChinhSachNghiPhep"] = new SelectList(_context.ChinhSachNghiPheps, "MaChinhSachNghiPhep", "MaChinhSachNghiPhep", apDungThamNien.MaChinhSachNghiPhep);
            ViewData["MaThamNien"] = new SelectList(_context.ChinhSachTheoThamNiens, "MaThamNien", "MaThamNien", apDungThamNien.MaThamNien);
            return View(apDungThamNien);
        }

        // GET: ApplySeniorityPolicies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apDungThamNien = await _context.ApDungThamNiens.FindAsync(id);
            if (apDungThamNien == null)
            {
                return NotFound();
            }
            ViewData["MaChinhSachNghiPhep"] = new SelectList(_context.ChinhSachNghiPheps, "MaChinhSachNghiPhep", "MaChinhSachNghiPhep", apDungThamNien.MaChinhSachNghiPhep);
            ViewData["MaThamNien"] = new SelectList(_context.ChinhSachTheoThamNiens, "MaThamNien", "MaThamNien", apDungThamNien.MaThamNien);
            return View(apDungThamNien);
        }

        // POST: ApplySeniorityPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChinhSachNghiPhep,MaThamNien")] ApDungThamNien apDungThamNien)
        {
            if (id != apDungThamNien.MaChinhSachNghiPhep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apDungThamNien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApDungThamNienExists(apDungThamNien.MaChinhSachNghiPhep))
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
            ViewData["MaChinhSachNghiPhep"] = new SelectList(_context.ChinhSachNghiPheps, "MaChinhSachNghiPhep", "MaChinhSachNghiPhep", apDungThamNien.MaChinhSachNghiPhep);
            ViewData["MaThamNien"] = new SelectList(_context.ChinhSachTheoThamNiens, "MaThamNien", "MaThamNien", apDungThamNien.MaThamNien);
            return View(apDungThamNien);
        }

        // GET: ApplySeniorityPolicies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apDungThamNien = await _context.ApDungThamNiens
                .Include(a => a.MaChinhSachNghiPhepNavigation)
                .Include(a => a.MaThamNienNavigation)
                .FirstOrDefaultAsync(m => m.MaChinhSachNghiPhep == id);
            if (apDungThamNien == null)
            {
                return NotFound();
            }

            return View(apDungThamNien);
        }

        // POST: ApplySeniorityPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var apDungThamNien = await _context.ApDungThamNiens.FindAsync(id);
            _context.ApDungThamNiens.Remove(apDungThamNien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApDungThamNienExists(string id)
        {
            return _context.ApDungThamNiens.Any(e => e.MaChinhSachNghiPhep == id);
        }
    }
}
