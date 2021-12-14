﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CreateRequestTimeoffForm_Version1.Models
{
    public partial class TypePersonnel
    {
        public TypePersonnel()
        {
            Personnel = new HashSet<Personnel>();
        }

        public string TypePersonnelId { get; set; }
        public string TypePersonnelName { get; set; }
        public string Describe { get; set; }
        public bool? States { get; set; }
        public bool? Del { get; set; }

        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
