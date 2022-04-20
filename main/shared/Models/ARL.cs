﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Models
{
    public class ARL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
