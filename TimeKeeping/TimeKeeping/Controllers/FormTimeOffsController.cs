using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeKeeping.Models;
using static TimeKeeping.Helper;

namespace TimeKeeping.Controllers
{
    public class FormTimeOffsController : Controller
    {
        private readonly TimeKeepingDBContext _context = new TimeKeepingDBContext();


        // GET: FormTimeOffs
        public async Task<IActionResult> Index()
        {
            var timeKeepingDBContext = _context.FormTimeOffs.Include(f => f.ApprovalProcess).Include(f => f.TypeTimeOff);
            return View(await timeKeepingDBContext.ToListAsync());
        }



        // GET: FormTimeOffs/AddOrEdit
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
            {
                ViewData["ApprovalProcessName"] = new SelectList(_context.ApprovalProcesses, "ApprovalProcessId", "ApprovalProcessName");
                ViewData["TypeTimeOffName"] = new SelectList(_context.TypeTimeOffs, "TypeTimeOffId", "TypeTimeOffName");
                return View(new FormTimeOff());
            }
            else
            {
                var formTimeOff = await _context.FormTimeOffs.FindAsync(id);
                if (formTimeOff == null)
                {
                    return NotFound();
                }
                ViewData["ApprovalProcessName"] = new SelectList(_context.ApprovalProcesses, "ApprovalProcessId", "ApprovalProcessName", formTimeOff.ApprovalProcessId);
                ViewData["TypeTimeOffName"] = new SelectList(_context.TypeTimeOffs, "TypeTimeOffId", "TypeTimeOffName", formTimeOff.TypeTimeOffId);
                return View(formTimeOff);
            }
        }

        // POST: FormTimeOffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, [Bind("FormTimeOffId,FormTimeOffName,TypeTimeOffId,RequireApproval,ApprovalProcessId,RequireLimitedDaysOff,ProcessingTime,NumberOfDaysBeforeTimeOff,LimitedDaysOff,Regulations,Del")] FormTimeOff formTimeOff)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    _context.Add(formTimeOff);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(formTimeOff);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FormTimeOffExists(formTimeOff.FormTimeOffId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.FormTimeOffs.ToList()) });
            }
            ViewData["ApprovalProcessName"] = new SelectList(_context.ApprovalProcesses, "ApprovalProcessId", "ApprovalProcessName", formTimeOff.ApprovalProcessId);
            ViewData["TypeTimeOffName"] = new SelectList(_context.TypeTimeOffs, "TypeTimeOffId", "TypeTimeOffName", formTimeOff.TypeTimeOffId);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", formTimeOff) });
        }

        // GET: FormTimeOffs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formTimeOff = await _context.FormTimeOffs
                .Include(f => f.ApprovalProcess)
                .Include(f => f.TypeTimeOff)
                .FirstOrDefaultAsync(m => m.FormTimeOffId == id);
            if (formTimeOff == null)
            {
                return NotFound();
            }

            return View(formTimeOff);
        }

        // POST: FormTimeOffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mauNghiPhep = await _context.FormTimeOffs.FindAsync(id);
            mauNghiPhep.Del = false;
            _context.FormTimeOffs.Update(mauNghiPhep);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.FormTimeOffs.ToList()) });
        }

        private bool FormTimeOffExists(string id)
        {
            return _context.FormTimeOffs.Any(e => e.FormTimeOffId == id);
        }
    }
}
