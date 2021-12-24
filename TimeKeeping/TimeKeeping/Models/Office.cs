using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Office
    {
        public Office()
        {
            Personnel = new HashSet<Personnel>();
        }

        public string OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeEmail { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
