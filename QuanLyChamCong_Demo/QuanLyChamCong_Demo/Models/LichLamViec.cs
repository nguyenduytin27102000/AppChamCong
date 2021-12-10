using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class LichLamViec
    {
        public LichLamViec()
        {
            CaLamViecs = new HashSet<CaLamViec>();
            NhanSus = new HashSet<NhanSu>();
        }

        public string MaLichLamViec { get; set; }
        public string TenLichLamViec { get; set; }
        public string MaLoaiLichLamViec { get; set; }
        public string MaChinhSachCheckin { get; set; }
        public string MaSoCaLamViec { get; set; }
        public bool? YeuCauCheckout { get; set; }
        public byte SoGioLamViecMoiNgay { get; set; }
        public byte SoPhutDuocTre { get; set; }
        public byte SoPhutVeSom { get; set; }
        public string QuyDinh { get; set; }
        public bool? TrangThai { get; set; }
        public bool? Xoa { get; set; }

        public virtual ChinhSachCheckin MaChinhSachCheckinNavigation { get; set; }
        public virtual LoaiLichLamViec MaLoaiLichLamViecNavigation { get; set; }
        public virtual SoCaLamViec MaSoCaLamViecNavigation { get; set; }
        public virtual ICollection<CaLamViec> CaLamViecs { get; set; }
        public virtual ICollection<NhanSu> NhanSus { get; set; }
    }
}
