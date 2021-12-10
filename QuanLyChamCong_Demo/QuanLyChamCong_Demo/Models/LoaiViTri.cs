using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class LoaiViTri
    {
        public LoaiViTri()
        {
            ViTris = new HashSet<ViTri>();
        }

        public string MaLoaiViTri { get; set; }
        public string TenLoaiViTri { get; set; }
        public string MoTa { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<ViTri> ViTris { get; set; }
    }
}
