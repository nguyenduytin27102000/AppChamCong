using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class LoaiChinhSach
    {
        public LoaiChinhSach()
        {
            ChinhSachNghiPheps = new HashSet<ChinhSachNghiPhep>();
        }

        [Display(Name = "Mã loại chính sách")]
        public string MaLoaiChinhSach { get; set; }

        [Display(Name = "Tên loại chính sách")]
        public string TenLoaiChinhSach { get; set; }

        [Display(Name = "Xóa")]
        public bool? Xoa { get; set; }

        public virtual ICollection<ChinhSachNghiPhep> ChinhSachNghiPheps { get; set; }
    }
}
