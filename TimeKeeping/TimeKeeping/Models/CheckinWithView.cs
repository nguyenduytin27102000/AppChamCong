using System;

namespace TimeKeeping.Models
{
    public class CheckinWithView
    {
        public string CheckinId { get; set; }
        public DateTime Time { get; set; }
        public string Personnal { get; set; }
        public string WorkScheduleName { get; set; }
        public int MinutesLate { get; set; }
        public int MinutesEarly { get; set; }
        public string Regulations { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? DayOff { get; set; }

    }
}
