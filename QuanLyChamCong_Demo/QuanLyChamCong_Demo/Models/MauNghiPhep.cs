using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping_Demo.Models
{
    public partial class MauNghiPhep
    {
        public MauNghiPhep()
        {
            KhuVucApDungMauNghiPheps = new HashSet<KhuVucApDungMauNghiPhep>();
            NguoiPheDuyetNghiPheps = new HashSet<NguoiPheDuyetNghiPhep>();
            NguoiTheoDoiNghiPheps = new HashSet<NguoiTheoDoiNghiPhep>();
            YeuCauNghiPheps = new HashSet<YeuCauNghiPhep>();
        }

        public string MaMauNghiPhep { get; set; }
        public string TenMauNghiPhep { get; set; }
        public string MaLoaiNghiPhep { get; set; }
        public bool? YeuCauPheDuyet { get; set; }
        public string MaQuyTrinhPheDuyet { get; set; }
        public bool? GioiHanNgayNghi { get; set; }
        public byte? ThoiHanXuLy { get; set; }
        public byte? SoNgayTruocNgayNghi { get; set; }
        public byte? GioiHanSoNgayNghi { get; set; }
        public string QuiDinh { get; set; }
        public bool? Xoa { get; set; }

        public virtual LoaiNghiPhep MaLoaiNghiPhepNavigation { get; set; }
        public virtual QuyTrinhPheDuyet MaQuyTrinhPheDuyetNavigation { get; set; }
        public virtual ICollection<KhuVucApDungMauNghiPhep> KhuVucApDungMauNghiPheps { get; set; }
        public virtual ICollection<NguoiPheDuyetNghiPhep> NguoiPheDuyetNghiPheps { get; set; }
        public virtual ICollection<NguoiTheoDoiNghiPhep> NguoiTheoDoiNghiPheps { get; set; }
        public virtual ICollection<YeuCauNghiPhep> YeuCauNghiPheps { get; set; }
    }
}
