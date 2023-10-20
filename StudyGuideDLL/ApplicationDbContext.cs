using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideDLL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleCalendar> ModuleCalendars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ModuleCalendar>()
                .HasOne(mc => mc.Module)
                .WithMany(m => m.ModuleCalendars)
                .HasForeignKey(mc => mc.ModuleId);
        }

    }
}
