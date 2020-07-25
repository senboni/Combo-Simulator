using ComboSimulator.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Models
{
    public class MysteryContext : DbContext
    {
        public MysteryContext(DbContextOptions<MysteryContext> options)
            : base(options)
        {
        }

        public DbSet<Mystery> Mysteries { get; set; }
    }
}
