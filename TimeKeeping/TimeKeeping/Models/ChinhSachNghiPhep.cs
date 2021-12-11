using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeKeeping.CustomValidation;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class ChinhSachNghiPhep
    {
        public ChinhSachNghiPhep()
        {
            ApDungThamNiens = new HashSet<ApDungThamNien>();
            NhanSuChinhSachNghiPheps = new HashSet<NhanSuChinhSachNghiPhep>();
        }

        [Display(Name = "Timeoff policy ID")]
        [Required(ErrorMessage = "Please enter timeoff policy ID!")]
        [StringLength(10, ErrorMessage = "Can enter 10 charaters")]
        //[MaChinhSachNghiPhepBiTrung]
        public string MaChinhSachNghiPhep { get; set; }

        [Display(Name = "Timeoff policy name")]
        [Required(ErrorMessage = "Please enter timeoff policy name!")]
        public string TenChinhSach { get; set; }

        [Display(Name = "Type of policy")]
        public string MaLoaiChinhSach { get; set; }

        [Display(Name = "Number of calibrations per year ")]
        [Required(ErrorMessage = "Please enter number of leave per year!")]
        public byte SoLuongPhepChuanNam { get; set; }

        [Display(Name = "Number of old leave per year")]
        [Required(ErrorMessage = "Please enter number of old leave per year!")]
        [SoPhepTonBeHonSoPhepTieuChuan("SoLuongPhepChuanNam")]
        public byte SoLuongPhepTon { get; set; }

        [Display(Name = "Discription")]
        [Required(ErrorMessage = "Please enter discription!")]
        public string MoTa { get; set; }

        [Display(Name = "Delete state")]
        public bool? Xoa { get; set; }

        [Display(Name = "Type of policy")]
        public virtual LoaiChinhSach MaLoaiChinhSachNavigation { get; set; }
        public virtual ICollection<ApDungThamNien> ApDungThamNiens { get; set; }
        public virtual ICollection<NhanSuChinhSachNghiPhep> NhanSuChinhSachNghiPheps { get; set; }
    }
}
