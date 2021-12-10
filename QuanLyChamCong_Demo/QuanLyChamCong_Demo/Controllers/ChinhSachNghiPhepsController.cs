using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyChamCong_Demo.Models;

namespace QuanLyChamCong_Demo.Controllers
{
    public class ChinhSachNghiPhepsController : Controller
    {
        private readonly QLCHAMCONGContext _context;

        public ChinhSachNghiPhepsController(QLCHAMCONGContext context)
        {
            _context = context;
        }
        // Thông báo để vào const

        // GET: ChinhSachNghiPheps
        public async Task<IActionResult> Index()
        {
            var qLCHAMCONGContext = _context.ChinhSachNghiPheps.Include(c => c.MaLoaiChinhSachNavigation);
            return View(await qLCHAMCONGContext.ToListAsync());
        }

        // GET: ChinhSachNghiPheps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chinhSachNghiPhep = await _context.ChinhSachNghiPheps
                .Include(c => c.MaLoaiChinhSachNavigation)
                .FirstOrDefaultAsync(m => m.MaChinhSachNghiPhep == id);
            if (chinhSachNghiPhep == null)
            {
                return NotFound();
            }

            return View(chinhSachNghiPhep);
        }

        // GET: ChinhSachNghiPheps/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiChinhSach"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "TenLoaiChinhSach");
            return View();
        }

        // POST: ChinhSachNghiPheps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChinhSachNghiPhep,TenChinhSach,MaLoaiChinhSach,SoLuongPhepChuanNam,SoLuongPhepTon,MoTa,Xoa")] ChinhSachNghiPhep chinhSachNghiPhep)
        {
            var dsChinhSachNghiPhep = _context.ChinhSachNghiPheps.ToList();

            foreach (var chinhSachNghiPhepCu in dsChinhSachNghiPhep)
            {
                if (chinhSachNghiPhep.MaChinhSachNghiPhep == chinhSachNghiPhepCu.MaChinhSachNghiPhep)
                {
                    ModelState.AddModelError("", "Mã này đã tồn tại trong danh sách!");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(chinhSachNghiPhep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiChinhSach"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "MaLoaiChinhSach", chinhSachNghiPhep.MaLoaiChinhSach);
            return View(chinhSachNghiPhep);
        }

        // GET: ChinhSachNghiPheps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var trangThaiXoa = new Dictionary<bool, string>()
            {
                {true, "Đang dùng" },
                {false, "Không dùng"}
            };


            if (id == null)
            {
                return NotFound();
            }

            var chinhSachNghiPhep = await _context.ChinhSachNghiPheps.FindAsync(id);
            if (chinhSachNghiPhep == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiChinhSach"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "TenLoaiChinhSach", chinhSachNghiPhep.MaLoaiChinhSach);

            ViewBag.TrangThaiXoa = new SelectList(trangThaiXoa, "Key", "Value");

            return View(chinhSachNghiPhep);
        }

        // POST: ChinhSachNghiPheps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChinhSachNghiPhep,TenChinhSach,MaLoaiChinhSach,SoLuongPhepChuanNam,SoLuongPhepTon,MoTa,Xoa")] ChinhSachNghiPhep chinhSachNghiPhep)
        {
            if (id != chinhSachNghiPhep.MaChinhSachNghiPhep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chinhSachNghiPhep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChinhSachNghiPhepExists(chinhSachNghiPhep.MaChinhSachNghiPhep))
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
            ViewData["MaLoaiChinhSach"] = new SelectList(_context.LoaiChinhSaches, "MaLoaiChinhSach", "MaLoaiChinhSach", chinhSachNghiPhep.MaLoaiChinhSach);
            return View(chinhSachNghiPhep);
        }

        // GET: ChinhSachNghiPheps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chinhSachNghiPhep = await _context.ChinhSachNghiPheps
                .Include(c => c.MaLoaiChinhSachNavigation)
                .FirstOrDefaultAsync(m => m.MaChinhSachNghiPhep == id);
            if (chinhSachNghiPhep == null)
            {
                return NotFound();
            }

            return View(chinhSachNghiPhep);
        }

        // POST: ChinhSachNghiPheps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chinhSachNghiPhep = await _context.ChinhSachNghiPheps.FindAsync(id);
            _context.ChinhSachNghiPheps.Remove(chinhSachNghiPhep);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChinhSachNghiPhepExists(string id)
        {
            return _context.ChinhSachNghiPheps.Any(e => e.MaChinhSachNghiPhep == id);
        }
    }
}
