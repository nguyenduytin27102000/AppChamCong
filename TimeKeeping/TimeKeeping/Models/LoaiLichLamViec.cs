using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class LoaiLichLamViec
    {
        public LoaiLichLamViec()
        {
            LichLamViecs = new HashSet<LichLamViec>();
        }

        public string MaLoaiLichLamViec { get; set; }
        public string TenLoaiLichLamViec { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<LichLamViec> LichLamViecs { get; set; }
    }
}
