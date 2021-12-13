using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TimeKeeping.ViewModels
{
    [BindProperties]
    public class TimeOffRequestModel
    {
        [DisplayName("Title *")]
        public string TieuDe { get; set; }
        [DisplayName("Time off form *")]
        public string MaMauNghiPhep { get; set; }
        [DisplayName("Reason *")]
        public string LyDoNghiPhep { get; set; }
        [DisplayName("Handover")]
        public bool BanGiaoCongViec { get; set; }
        [DisplayName("Handover works")]
        public string CacCongViecBanGiao { get; set; }
        [DisplayName("Approver *")]
        public string MaNguoiQuanLy { get; set; }
        //public string TaiLieuDinhKem { get; set; }
        [DisplayName("Attachment")]
        public IFormFile TaiLieuDinhKem { get; set; }
    }
}
