using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class LoaiChinhSach
    {
        public LoaiChinhSach()
        {
            ChinhSachNghiPheps = new HashSet<ChinhSachNghiPhep>();
        }

        public string MaLoaiChinhSach { get; set; }
        public string TenLoaiChinhSach { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<ChinhSachNghiPhep> ChinhSachNghiPheps { get; set; }
    }
}
