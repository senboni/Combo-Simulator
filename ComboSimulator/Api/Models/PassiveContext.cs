using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public class PassiveContext : DbContext
    {
        public PassiveContext(DbContextOptions<PassiveContext> options)
            : base(options)
        {
        }

        public DbSet<Passive> Passives { get; set; }
    }
}
