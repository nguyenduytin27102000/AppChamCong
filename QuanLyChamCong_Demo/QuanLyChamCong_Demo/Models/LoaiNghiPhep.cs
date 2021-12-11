using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class LoaiNghiPhep
    {
        public LoaiNghiPhep()
        {
            MauNghiPheps = new HashSet<MauNghiPhep>();
        }

        public string MaLoaiNghiPhep { get; set; }
        public string TenLoaiNghiPhep { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<MauNghiPhep> MauNghiPheps { get; set; }
    }
}
