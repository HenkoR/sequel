﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Client
    {

        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}
}
