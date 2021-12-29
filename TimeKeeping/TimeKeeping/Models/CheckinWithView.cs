using System;
using System.ComponentModel;

namespace TimeKeeping.Models
{
    public class CheckinWithView
    {
        public string CheckinId { get; set; }
        [DisplayName("Date")]
        public DateTime Time { get; set; }
        [DisplayName("Person")]
        public string Personnal { get; set; }
        [DisplayName("Work Schedule Name")]
        public string WorkScheduleName { get; set; }
        [DisplayName("Minutes Late")]
        public int MinutesLate { get; set; }
        [DisplayName("Minutes Early")]
        public int MinutesEarly { get; set; }

        public string Regulations { get; set; }
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }
        public bool? DayOff { get; set; }

    }
}
