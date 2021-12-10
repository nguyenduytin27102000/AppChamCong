using QuanLyChamCong_Demo.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class ChinhSachNghiPhep
    {
        public ChinhSachNghiPhep()
        {
            ApDungThamNiens = new HashSet<ApDungThamNien>();
            NhanSuChinhSachNghiPheps = new HashSet<NhanSuChinhSachNghiPhep>();
        }

        [Display(Name = "Mã chính sách nghỉ phép")]
        [Required(ErrorMessage = "Vui lòng nhập mã chính sách!")]
        //[MaChinhSachNghiPhepBiTrung]
        public string MaChinhSachNghiPhep { get; set; }

        [Display(Name = "Tên chính sách")]
        [Required(ErrorMessage = "Vui lòng nhập tên chính sách!")]
        public string TenChinhSach { get; set; }

        [Display(Name = "Loại chính sách")]
        public string MaLoaiChinhSach { get; set; }

        [Display(Name = "Số lượng phép chuẩn năm")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng phép chuẩn năm!")]
        public byte SoLuongPhepChuanNam { get; set; }

        [Display(Name = "Số lượng phép tồn")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng phép tồn")]
        [SoPhepTonBeHonSoPhepTieuChuan("SoLuongPhepChuanNam")]
        public byte SoLuongPhepTon { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả!")]
        public string MoTa { get; set; }

        [Display(Name = "Xóa")]
        public bool? Xoa { get; set; }

        [Display(Name = "Loại chính sách")]
        public virtual LoaiChinhSach MaLoaiChinhSachNavigation { get; set; }
        public virtual ICollection<ApDungThamNien> ApDungThamNiens { get; set; }
        public virtual ICollection<NhanSuChinhSachNghiPhep> NhanSuChinhSachNghiPheps { get; set; }
    }
}
