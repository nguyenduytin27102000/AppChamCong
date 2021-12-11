using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeKeeping_Demo.Models;

namespace TimeKeeping_Demo.Controllers
{
    public class PolicyTypesController : Controller
    {
        private readonly TimekeepingContext _context;

        public PolicyTypesController(TimekeepingContext context)
        {
            _context = context;
        }

        // GET: LoaiChinhSaches
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiChinhSaches.ToListAsync());
        }

        // GET: LoaiChinhSaches/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiChinhSach = await _context.LoaiChinhSaches
                .FirstOrDefaultAsync(m => m.MaLoaiChinhSach == id);
            if (loaiChinhSach == null)
            {
                return NotFound();
            }

            return View(loaiChinhSach);
        }

        // GET: LoaiChinhSaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiChinhSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoaiChinhSach,TenLoaiChinhSach,Xoa")] LoaiChinhSach loaiChinhSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiChinhSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiChinhSach);
        }

        // GET: LoaiChinhSaches/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiChinhSach = await _context.LoaiChinhSaches.FindAsync(id);
            if (loaiChinhSach == null)
            {
                return NotFound();
            }
            return View(loaiChinhSach);
        }

        // POST: LoaiChinhSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLoaiChinhSach,TenLoaiChinhSach,Xoa")] LoaiChinhSach loaiChinhSach)
        {
            if (id != loaiChinhSach.MaLoaiChinhSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiChinhSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiChinhSachExists(loaiChinhSach.MaLoaiChinhSach))
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
            return View(loaiChinhSach);
        }

        // GET: LoaiChinhSaches/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiChinhSach = await _context.LoaiChinhSaches
                .FirstOrDefaultAsync(m => m.MaLoaiChinhSach == id);
            if (loaiChinhSach == null)
            {
                return NotFound();
            }

            return View(loaiChinhSach);
        }

        // POST: LoaiChinhSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loaiChinhSach = await _context.LoaiChinhSaches.FindAsync(id);
            _context.LoaiChinhSaches.Remove(loaiChinhSach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiChinhSachExists(string id)
        {
            return _context.LoaiChinhSaches.Any(e => e.MaLoaiChinhSach == id);
        }
    }
}
