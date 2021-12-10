using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyChamCong_Demo.Models;

namespace QuanLyChamCong_Demo.Controllers
{
    public class ChinhSachTheoThamNiensController : Controller
    {
        private readonly QLCHAMCONGContext _context;

        public ChinhSachTheoThamNiensController(QLCHAMCONGContext context)
        {
            _context = context;
        }

        // GET: ChinhSachTheoThamNiens
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChinhSachTheoThamNiens.ToListAsync());
        }

        // GET: ChinhSachTheoThamNiens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chinhSachTheoThamNien = await _context.ChinhSachTheoThamNiens
                .FirstOrDefaultAsync(m => m.MaThamNien == id);
            if (chinhSachTheoThamNien == null)
            {
                return NotFound();
            }

            return View(chinhSachTheoThamNien);
        }

        // GET: ChinhSachTheoThamNiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChinhSachTheoThamNiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThamNien,ThamNien,SoNgayTang,Xoa")] ChinhSachTheoThamNien chinhSachTheoThamNien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chinhSachTheoThamNien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chinhSachTheoThamNien);
        }

        // GET: ChinhSachTheoThamNiens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chinhSachTheoThamNien = await _context.ChinhSachTheoThamNiens.FindAsync(id);
            if (chinhSachTheoThamNien == null)
            {
                return NotFound();
            }
            return View(chinhSachTheoThamNien);
        }

        // POST: ChinhSachTheoThamNiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaThamNien,ThamNien,SoNgayTang,Xoa")] ChinhSachTheoThamNien chinhSachTheoThamNien)
        {
            if (id != chinhSachTheoThamNien.MaThamNien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chinhSachTheoThamNien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChinhSachTheoThamNienExists(chinhSachTheoThamNien.MaThamNien))
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
            return View(chinhSachTheoThamNien);
        }

        // GET: ChinhSachTheoThamNiens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chinhSachTheoThamNien = await _context.ChinhSachTheoThamNiens
                .FirstOrDefaultAsync(m => m.MaThamNien == id);
            if (chinhSachTheoThamNien == null)
            {
                return NotFound();
            }

            return View(chinhSachTheoThamNien);
        }

        // POST: ChinhSachTheoThamNiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chinhSachTheoThamNien = await _context.ChinhSachTheoThamNiens.FindAsync(id);
            _context.ChinhSachTheoThamNiens.Remove(chinhSachTheoThamNien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChinhSachTheoThamNienExists(string id)
        {
            return _context.ChinhSachTheoThamNiens.Any(e => e.MaThamNien == id);
        }
    }
}
