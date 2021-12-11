using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class YeuCauNghiPhep
    {
        public YeuCauNghiPhep()
        {
            CaNghiPheps = new HashSet<CaNghiPhep>();
            NgayNghiPheps = new HashSet<NgayNghiPhep>();
        }

        public string MaNhanSu { get; set; }
        public string MaYeuCauNghiPhep { get; set; }
        public string TieuDe { get; set; }
        public string MaMauNghiPhep { get; set; }
        public string LyDoNghiPhep { get; set; }
        public bool BanGiaoCongViec { get; set; }
        public string CacCongViecBanGiao { get; set; }
        public string MaNguoiQuanLy { get; set; }
        public string TaiLieuDinhKem { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
        public string PhanHoi { get; set; }
        public bool? Xoa { get; set; }

        public virtual MauNghiPhep MaMauNghiPhepNavigation { get; set; }
        public virtual NhanSu MaNguoiQuanLyNavigation { get; set; }
        public virtual NhanSu MaNhanSuNavigation { get; set; }
        public virtual ICollection<CaNghiPhep> CaNghiPheps { get; set; }
        public virtual ICollection<NgayNghiPhep> NgayNghiPheps { get; set; }
    }
}
