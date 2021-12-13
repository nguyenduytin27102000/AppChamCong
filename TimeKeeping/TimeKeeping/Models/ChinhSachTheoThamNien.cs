using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class ChinhSachTheoThamNien
    {
        public ChinhSachTheoThamNien()
        {
            ApDungThamNiens = new HashSet<ApDungThamNien>();
        }

        public string MaThamNien { get; set; }
        public int ThamNien { get; set; }
        public byte SoNgayTang { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<ApDungThamNien> ApDungThamNiens { get; set; }
    }
}
