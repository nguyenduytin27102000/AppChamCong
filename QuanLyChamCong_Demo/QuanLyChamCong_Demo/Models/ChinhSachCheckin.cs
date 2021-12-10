using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class ChinhSachCheckin
    {
        public ChinhSachCheckin()
        {
            LichLamViecs = new HashSet<LichLamViec>();
        }

        public string MaChinhSachCheckin { get; set; }
        public string TenChinhSachCheckin { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<LichLamViec> LichLamViecs { get; set; }
    }
}
