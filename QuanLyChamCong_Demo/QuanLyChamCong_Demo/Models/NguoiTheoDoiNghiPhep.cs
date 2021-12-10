using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class NguoiTheoDoiNghiPhep
    {
        public string MaNhanSu { get; set; }
        public string MaMauNghiPhep { get; set; }
        public bool? Xoa { get; set; }

        public virtual MauNghiPhep MaMauNghiPhepNavigation { get; set; }
        public virtual NhanSu MaNhanSuNavigation { get; set; }
    }
}
