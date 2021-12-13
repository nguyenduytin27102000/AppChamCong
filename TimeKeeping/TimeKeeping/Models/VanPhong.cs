using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class VanPhong
    {
        public VanPhong()
        {
            NhanSus = new HashSet<NhanSu>();
        }

        public string MaVp { get; set; }
        public string TenVp { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<NhanSu> NhanSus { get; set; }
    }
}
