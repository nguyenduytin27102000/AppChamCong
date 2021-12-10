using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyChamCong_Demo.Models;

namespace QuanLyChamCong_Demo.Controllers
{
    public class ApDungThamNiensController : Controller
    {
        private readonly QLCHAMCONGContext _context;

        public ApDungThamNiensController(QLCHAMCONGContext context)
        {
            _context = context;
        }

        // GET: ApDungThamNiens
        public async Task<IActionResult> Index()
        {
            var qLCHAMCONGContext = _context.ApDungThamNiens.Include(a => a.MaChinhSachNghiPhepNavigation).Include(a => a.MaThamNienNavigation);
            return View(await qLCHAMCONGContext.ToListAsync());
        }

        // GET: ApDungThamNiens/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: ApDungThamNiens/Create
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

        // GET: ApDungThamNiens/Edit/5
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

        // POST: ApDungThamNiens/Edit/5
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

        // GET: ApDungThamNiens/Delete/5
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

        // POST: ApDungThamNiens/Delete/5
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
