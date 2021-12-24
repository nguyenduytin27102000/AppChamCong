using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Checkin
    {
        public string CheckinId { get; set; }
        public string PersonnelId { get; set; }
        public DateTime Time { get; set; }
        public bool? Active { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}
