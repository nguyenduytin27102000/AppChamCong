using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TypePosition
    {
        public TypePosition()
        {
            Positions = new HashSet<Position>();
        }

        public string TypePositionId { get; set; }
        public string TypePositionName { get; set; }
        public string Describe { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
