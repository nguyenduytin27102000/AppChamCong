using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class KhuVucNghiepVu
    {
        public KhuVucNghiepVu()
        {
            KhuVucApDungMauNghiPheps = new HashSet<KhuVucApDungMauNghiPhep>();
            NhanSus = new HashSet<NhanSu>();
            ViTris = new HashSet<ViTri>();
        }

        public string MaKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<KhuVucApDungMauNghiPhep> KhuVucApDungMauNghiPheps { get; set; }
        public virtual ICollection<NhanSu> NhanSus { get; set; }
        public virtual ICollection<ViTri> ViTris { get; set; }
    }
}
