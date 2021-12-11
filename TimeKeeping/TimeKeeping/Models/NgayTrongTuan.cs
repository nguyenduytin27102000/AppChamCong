using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class NgayTrongTuan
    {
        public NgayTrongTuan()
        {
            CaLamViecs = new HashSet<CaLamViec>();
        }

        public string MaNgayTrongTuan { get; set; }
        public string TenNgayTrongTuan { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<CaLamViec> CaLamViecs { get; set; }
    }
}
