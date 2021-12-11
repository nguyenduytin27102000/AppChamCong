using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class LoaiCaLamViec
    {
        public LoaiCaLamViec()
        {
            CaLamViecs = new HashSet<CaLamViec>();
        }

        public string MaLoaiCaLamViec { get; set; }
        public string TenLoaiCaLamViec { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<CaLamViec> CaLamViecs { get; set; }
    }
}
