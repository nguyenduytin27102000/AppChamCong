using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class Position
    {
        public Position()
        {
            Personnel = new HashSet<Personnel>();
        }

        public string PositionId { get; set; }
        public string PositionName { get; set; }
        public string WorkingAreaId { get; set; }
        public string TypePositionId { get; set; }
        public decimal LowestSalary { get; set; }
        public decimal HighestSalary { get; set; }
        public bool? Active { get; set; }

        public virtual TypePosition TypePosition { get; set; }
        public virtual WorkingArea WorkingArea { get; set; }
        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
