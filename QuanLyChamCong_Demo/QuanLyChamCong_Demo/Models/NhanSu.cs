using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class NhanSu
    {
        public NhanSu()
        {
            NguoiPheDuyetNghiPheps = new HashSet<NguoiPheDuyetNghiPhep>();
            NguoiTheoDoiNghiPheps = new HashSet<NguoiTheoDoiNghiPhep>();
            NhanSuChinhSachNghiPheps = new HashSet<NhanSuChinhSachNghiPhep>();
            YeuCauNghiPhepMaNguoiQuanLyNavigations = new HashSet<YeuCauNghiPhep>();
            YeuCauNghiPhepMaNhanSuNavigations = new HashSet<YeuCauNghiPhep>();
        }

        public string MaNhanSu { get; set; }
        public string HoVaTenDem { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string MaVp { get; set; }
        public string MaLichLamViec { get; set; }
        public string MaKhuVuc { get; set; }
        public string MaViTri { get; set; }
        public string MaChinhSachLuong { get; set; }
        public string MaLoaiHinhNhanSu { get; set; }
        public string ChucDanh { get; set; }
        public decimal LuongThucNhan { get; set; }
        public decimal LuongCoBan { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public DateTime? NgayChinhThuc { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Sdt { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public bool? Xoa { get; set; }

        public virtual ChinhSachLuong MaChinhSachLuongNavigation { get; set; }
        public virtual KhuVucNghiepVu MaKhuVucNavigation { get; set; }
        public virtual LichLamViec MaLichLamViecNavigation { get; set; }
        public virtual LoaiHinhNhanSu MaLoaiHinhNhanSuNavigation { get; set; }
        public virtual ViTri MaViTriNavigation { get; set; }
        public virtual VanPhong MaVpNavigation { get; set; }
        public virtual ICollection<NguoiPheDuyetNghiPhep> NguoiPheDuyetNghiPheps { get; set; }
        public virtual ICollection<NguoiTheoDoiNghiPhep> NguoiTheoDoiNghiPheps { get; set; }
        public virtual ICollection<NhanSuChinhSachNghiPhep> NhanSuChinhSachNghiPheps { get; set; }
        public virtual ICollection<YeuCauNghiPhep> YeuCauNghiPhepMaNguoiQuanLyNavigations { get; set; }
        public virtual ICollection<YeuCauNghiPhep> YeuCauNghiPhepMaNhanSuNavigations { get; set; }
    }
}
