﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class ProjectDateTime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Duration { get; set; }

    }
}
