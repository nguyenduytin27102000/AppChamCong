using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimeKeeping.ViewModels
{
    [BindProperties]
    public class TimeOffRequestModel
    {
        [DisplayName("Title *")]
        public string Title { get; set; }
        [DisplayName("Time off form *")]
        public string FormTimeOffId { get; set; }
        [DisplayName("Reason *")]
        public string Reason { get; set; }
        [DisplayName("Handover")]
        public bool RequireHandOver { get; set; }
        [DisplayName("Handover works")]
        public string HandOverWorks { get; set; }
        [DisplayName("Approver *")]
        public string ManagerId { get; set; }
        //public string TaiLieuDinhKem { get; set; }
        [DisplayName("Attachment")]
        public IFormFile Attachment { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; } = DateTime.Now;
        // there are 3 options (1: half day, 2: full day, 3: specify time)
        public int Duration { get; set; }
        public string FromHour { get; set; }
        public string ToHour { get; set; }
        public string HalfDay { get; set; }

    }
}
