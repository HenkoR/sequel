using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class EmpContext : DbContext
    {
         public EmpContext(DbContextOptions<EmpContext> options)
                : base(options)
            { }

            public DbSet<EmpDetails> Entries { get; set; }

    }
}
