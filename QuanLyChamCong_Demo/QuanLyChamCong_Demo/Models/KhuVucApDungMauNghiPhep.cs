﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyChamCong_Demo.Models
{
    public partial class KhuVucApDungMauNghiPhep
    {
        public string MaKhuVuc { get; set; }
        public string MaMauNghiPhep { get; set; }
        public bool? Xoa { get; set; }

        public virtual KhuVucNghiepVu MaKhuVucNavigation { get; set; }
        public virtual MauNghiPhep MaMauNghiPhepNavigation { get; set; }
    }
}
