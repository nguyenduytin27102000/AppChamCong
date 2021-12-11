using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class NhanSuChinhSachNghiPhep
    {
        public string MaNhanSu { get; set; }
        public string MaChinhSachNghiPhep { get; set; }
        public DateTime NgayCoHieuLuc { get; set; }
        public byte PhepTon { get; set; }
        public byte PhepTrongNam { get; set; }
        public byte PhepThamNien { get; set; }
        public byte NghiBu { get; set; }
        public string GhiChu { get; set; }
        public bool? Xoa { get; set; }

        public virtual ChinhSachNghiPhep MaChinhSachNghiPhepNavigation { get; set; }
        public virtual NhanSu MaNhanSuNavigation { get; set; }
    }
}
