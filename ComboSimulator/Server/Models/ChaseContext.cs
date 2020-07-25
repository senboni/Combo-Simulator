using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Models
{
    public class ChaseContext : DbContext
    {
        public ChaseContext(DbContextOptions<ChaseContext> options)
            : base(options)
        {
        }

        public DbSet<Chase> Chases { get; set; }
    }
}
