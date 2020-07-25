using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Api.Models
{
    public class AttackContext : DbContext
    {
        public AttackContext(DbContextOptions<AttackContext> options)
            : base(options)
        {
        }

        public DbSet<Attack> Attacks { get; set; }
    }
}
