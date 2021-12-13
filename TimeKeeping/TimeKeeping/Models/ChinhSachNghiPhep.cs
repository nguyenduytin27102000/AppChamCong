using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class ChinhSachNghiPhep
    {
        public ChinhSachNghiPhep()
        {
            ApDungThamNiens = new HashSet<ApDungThamNien>();
            NhanSuChinhSachNghiPheps = new HashSet<NhanSuChinhSachNghiPhep>();
        }

        public string MaChinhSachNghiPhep { get; set; }
        public string TenChinhSach { get; set; }
        public string MaLoaiChinhSach { get; set; }
        public byte SoLuongPhepChuanNam { get; set; }
        public byte SoLuongPhepTon { get; set; }
        public string MoTa { get; set; }
        public bool? Xoa { get; set; }

        public virtual LoaiChinhSach MaLoaiChinhSachNavigation { get; set; }
        public virtual ICollection<ApDungThamNien> ApDungThamNiens { get; set; }
        public virtual ICollection<NhanSuChinhSachNghiPhep> NhanSuChinhSachNghiPheps { get; set; }
    }
}
