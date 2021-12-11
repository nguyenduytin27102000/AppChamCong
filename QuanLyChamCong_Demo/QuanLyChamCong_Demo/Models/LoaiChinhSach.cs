using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class LoaiChinhSach
    {
        public LoaiChinhSach()
        {
            ChinhSachNghiPheps = new HashSet<ChinhSachNghiPhep>();
        }

        [Display(Name = "Policy ID")]
        public string MaLoaiChinhSach { get; set; }

        [Display(Name = "Policy name")]
        public string TenLoaiChinhSach { get; set; }

        [Display(Name = "Delete State")]
        public bool? Xoa { get; set; }

        public virtual ICollection<ChinhSachNghiPhep> ChinhSachNghiPheps { get; set; }
    }
}
