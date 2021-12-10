using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class QuyTrinhPheDuyet
    {
        public QuyTrinhPheDuyet()
        {
            MauNghiPheps = new HashSet<MauNghiPhep>();
        }

        public string MaQuyTrinhPheDuyet { get; set; }
        public string TenQuyTrinhPheDuyet { get; set; }
        public bool? Xoa { get; set; }

        public virtual ICollection<MauNghiPhep> MauNghiPheps { get; set; }
    }
}
