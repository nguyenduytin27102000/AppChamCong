using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TypeTimeOff
    {
        public TypeTimeOff()
        {
            FormTimeOffs = new HashSet<FormTimeOff>();
        }

        public string TypeTimeOffId { get; set; }
        public string TypeTimeOffName { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<FormTimeOff> FormTimeOffs { get; set; }
    }
}
