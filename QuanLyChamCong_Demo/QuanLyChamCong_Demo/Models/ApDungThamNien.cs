using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class ApDungThamNien
    {
        [Display(Name = "Chính sách nghỉ phép")]
        public string MaChinhSachNghiPhep { get; set; }

        [Display(Name = "Thâm niên")]
        public string MaThamNien { get; set; }

        [Display(Name = "Chính sách nghỉ phép")]
        public virtual ChinhSachNghiPhep MaChinhSachNghiPhepNavigation { get; set; }

        [Display(Name = "Thâm niên")]
        public virtual ChinhSachTheoThamNien MaThamNienNavigation { get; set; }
    }
}
