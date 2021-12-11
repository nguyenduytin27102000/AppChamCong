using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class ChinhSachTheoThamNien
    {
        public ChinhSachTheoThamNien()
        {
            ApDungThamNiens = new HashSet<ApDungThamNien>();
        }

        [Display(Name = "Seniority ID")]
        public string MaThamNien { get; set; }

        [Display(Name = "Seniority")]
        public int ThamNien { get; set; }

        [Display(Name = "Number of days increase")]
        public byte SoNgayTang { get; set; }

        [Display(Name = "Delete state")]
        public bool? Xoa { get; set; }

        public virtual ICollection<ApDungThamNien> ApDungThamNiens { get; set; }
    }
}
