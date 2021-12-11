using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class ViTri
    {
        public ViTri()
        {
            NhanSus = new HashSet<NhanSu>();
        }

        public string MaViTri { get; set; }
        public string TenViTri { get; set; }
        public string MaKhuVuc { get; set; }
        public string MaLoaiViTri { get; set; }
        public decimal MucLuongThapNhat { get; set; }
        public decimal MucLuongCaoNhat { get; set; }
        public bool? Xoa { get; set; }

        public virtual KhuVucNghiepVu MaKhuVucNavigation { get; set; }
        public virtual LoaiViTri MaLoaiViTriNavigation { get; set; }
        public virtual ICollection<NhanSu> NhanSus { get; set; }
    }
}
