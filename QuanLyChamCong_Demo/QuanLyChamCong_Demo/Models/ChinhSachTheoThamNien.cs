using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class ChinhSachTheoThamNien
    {
        public ChinhSachTheoThamNien()
        {
            ApDungThamNiens = new HashSet<ApDungThamNien>();
        }

        [Display(Name = "Mã thâm niên")]
        public string MaThamNien { get; set; }

        [Display(Name = "Thâm niên")]
        public int ThamNien { get; set; }

        [Display(Name = "Số ngày tăng")]
        public byte SoNgayTang { get; set; }

        [Display(Name = "Xóa")]
        public bool? Xoa { get; set; }

        public virtual ICollection<ApDungThamNien> ApDungThamNiens { get; set; }
    }
}
