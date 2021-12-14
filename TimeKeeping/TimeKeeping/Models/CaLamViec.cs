using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class CaLamViec
    {
        public CaLamViec()
        {
            CaNghiPheps = new HashSet<CaNghiPhep>();
        }

        public string MaLichLamViec { get; set; }
        public string MaNgayTrongTuan { get; set; }
        public string MaCaLamViec { get; set; }
        public string MaLoaiCaLamViec { get; set; }
        public string TenCaLamViec { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public bool? NgayNghi { get; set; }
        public bool? Xoa { get; set; }

        public virtual LichLamViec MaLichLamViecNavigation { get; set; }
        public virtual LoaiCaLamViec MaLoaiCaLamViecNavigation { get; set; }
        public virtual NgayTrongTuan MaNgayTrongTuanNavigation { get; set; }
        public virtual ICollection<CaNghiPhep> CaNghiPheps { get; set; }
    }
}
