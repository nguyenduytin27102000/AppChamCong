using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class SoCaLamViec
    {
        public SoCaLamViec()
        {
            LichLamViecs = new HashSet<LichLamViec>();
        }

        public string MaSoCaLamViec { get; set; }
        public byte SoCaLamViec1 { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<LichLamViec> LichLamViecs { get; set; }
    }
}
