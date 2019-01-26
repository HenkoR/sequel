using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class DeveloperContext : DbContext 
    {
        public DeveloperContext(DbContextOptions<DeveloperContext> options)
            : base(options)
        { }

        public DbSet<Developer> Entries { get; set; }
    }
}

