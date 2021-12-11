using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class ApDungThamNien
    {
        [Display(Name = "Timeoff policy")]
        public string MaChinhSachNghiPhep { get; set; }

        [Display(Name = "Seniority Policy")]
        public string MaThamNien { get; set; }

        [Display(Name = "Timeoff policy")]
        public virtual ChinhSachNghiPhep MaChinhSachNghiPhepNavigation { get; set; }

        [Display(Name = "Seniority Policy")]
        public virtual ChinhSachTheoThamNien MaThamNienNavigation { get; set; }
    }
}
