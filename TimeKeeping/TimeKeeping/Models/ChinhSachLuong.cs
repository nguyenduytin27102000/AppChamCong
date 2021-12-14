using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class ChinhSachLuong
    {
        public ChinhSachLuong()
        {
            NhanSus = new HashSet<NhanSu>();
        }

        public string MaChinhSachLuong { get; set; }
        public string TenChinhSachLuong { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<NhanSu> NhanSus { get; set; }
    }
}
