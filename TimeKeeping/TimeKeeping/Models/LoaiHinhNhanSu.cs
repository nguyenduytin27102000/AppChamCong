using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class LoaiHinhNhanSu
    {
        public LoaiHinhNhanSu()
        {
            NhanSus = new HashSet<NhanSu>();
        }

        public string MaLoaiHinhNhanSu { get; set; }
        public string TenLoaiHinhNhanSu { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<NhanSu> NhanSus { get; set; }
    }
}
