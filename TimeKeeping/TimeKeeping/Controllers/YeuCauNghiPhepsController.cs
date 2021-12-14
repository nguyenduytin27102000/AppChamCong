using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TimeKeeping.Models;
using TimeKeeping.Services;
using TimeKeeping.ViewModels;

namespace TimeKeeping.Controllers
{
    public class YeuCauNghiPhepsController : Controller
    {
        private readonly QLChamCongContext _context;
        private readonly IMapper _mapper;
        private readonly IdentityFactory _identityFactory;
        private readonly IHostingEnvironment _hostingEnvironment;

        public YeuCauNghiPhepsController(QLChamCongContext context, IMapper mapper, 
            IdentityFactory identityFactory, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _identityFactory = identityFactory;
            _hostingEnvironment = hostingEnvironment;

        }

        public IActionResult Create()
        {
            ViewData["Shifts"] = GetShifts().Result;
            ViewData["MaMauNghiPhep"] = new SelectList(_context.MauNghiPheps, "MaMauNghiPhep", "TenMauNghiPhep");
            ViewData["MaNguoiQuanLy"] = new SelectList(_context.NhanSus, "MaNhanSu", "Ten");
            ViewData["MaNhanSu"] = new SelectList(_context.NhanSus, "MaNhanSu", "Ten");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeOffRequestModel timeOffRequestModel, IFormCollection formData)
        {
            //HttpContext.Session.SetString("userId", "1");
            YeuCauNghiPhep yeuCauNghiPhep = _mapper.Map<YeuCauNghiPhep>(timeOffRequestModel);

            yeuCauNghiPhep.MaYeuCauNghiPhep = _identityFactory.GenerateId(_context.YeuCauNghiPheps.Max(m => m.MaYeuCauNghiPhep), "NS");
            yeuCauNghiPhep.MaNhanSu = "1";// lấy thông tin bằng Session
            yeuCauNghiPhep.TrangThai = "Pending";

            if (timeOffRequestModel.TaiLieuDinhKem != null)
            {
                string extension = Path.GetExtension(timeOffRequestModel.TaiLieuDinhKem.FileName);
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "storage", "attachments", yeuCauNghiPhep.MaYeuCauNghiPhep + extension);
                using (var stream = System.IO.File.Create(uploadFolder))
                {
                    await timeOffRequestModel.TaiLieuDinhKem.CopyToAsync(stream);
                    yeuCauNghiPhep.TaiLieuDinhKem = yeuCauNghiPhep.MaYeuCauNghiPhep + extension;
                }

            }
            // insert shift off
            int dateOffCount = int.Parse(formData["DateOffCount"]);

            var offDates = new List<NgayNghiPhep>();
            var shifts = new List<CaNghiPhep>();
            var dayoffCurrentId = _context.NgayNghiPheps.Max(m => m.MaNgayNghiPhep);

            for (int i = 1; i <= dateOffCount; i++)
            {
                var date = DateTime.Parse(formData[$"Date{i}"]);
                
                NgayNghiPhep ngayNghiPhep = new NgayNghiPhep()
                {
                    MaNgayNghiPhep = _identityFactory.GenerateId(dayoffCurrentId, "NP"),
                    MaYeuCauNghiPhep = yeuCauNghiPhep.MaYeuCauNghiPhep,
                    NgayNghi = date,
                    Xoa = false
                };

                dayoffCurrentId = ngayNghiPhep.MaNgayNghiPhep;

                // get shift id array
                var shiftIds = formData[$"DateShitfId{i}"];

                foreach (var shiftId in shiftIds)
                {
                    CaNghiPhep caNghiPhep = new CaNghiPhep()
                    {
                        MaNgayNghiPhep = ngayNghiPhep.MaNgayNghiPhep,
                        MaYeuCauNghiPhep = yeuCauNghiPhep.MaYeuCauNghiPhep,
                        MaCaLamViec = shiftId,
                        Xoa = false
                    };
                    shifts.Add(caNghiPhep);
                }
                offDates.Add(ngayNghiPhep);
            }


            var t1 = _context.YeuCauNghiPheps.AddRangeAsync(yeuCauNghiPhep);
            var t2 = _context.NgayNghiPheps.AddRangeAsync(offDates);
            var t3 = _context.CaNghiPheps.AddRangeAsync(shifts);
            try
            {
                await Task.WhenAll(t1, t2, t3);
                _context.SaveChanges(true);
                ViewBag.message = "You have successfully sent time off request";
                ViewBag.status = "success";
            }
            catch (Exception ex)
            {
                ViewBag.message = $"Sorry, an error occurred: {ex.Message}";
                ViewBag.status = "danger";
            }

            ViewData["Shifts"] = GetShifts().Result;
            ViewData["MaMauNghiPhep"] = new SelectList(_context.MauNghiPheps, "MaMauNghiPhep", "TenMauNghiPhep");
            ViewData["MaNguoiQuanLy"] = new SelectList(_context.NhanSus, "MaNhanSu", "Ten");
            ViewData["MaNhanSu"] = new SelectList(_context.NhanSus, "MaNhanSu", "Ten");
            return View();
        }

        private async Task<string> GetShifts()
        {
            //var staffId = HttpContext.Session.GetString("userId");
            var staff = await _context.NhanSus.FindAsync("1");
            var shifts = _context.LichLamViecs.Find(staff.MaLichLamViec).CaLamViecs
                .Select(m => new {
                    Id = m.MaCaLamViec,
                    Start = m.ThoiGianBatDau.Hour + ":" + m.ThoiGianBatDau.Minute.ToString().PadLeft(2, '0'),
                    End = m.ThoiGianKetThuc.Hour + ":" + m.ThoiGianKetThuc.Minute.ToString().PadLeft(2, '0')
                }).ToList();
            string json = JsonConvert.SerializeObject(shifts);
            return json;
        }

        private bool YeuCauNghiPhepExists(string id)
        {
            return _context.YeuCauNghiPheps.Any(e => e.MaYeuCauNghiPhep == id);
        }
    }
}
