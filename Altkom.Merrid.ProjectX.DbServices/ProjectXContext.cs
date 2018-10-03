using Altkom.Merrid.ProjectX.DbServices.Configurations;
using Altkom.Merrid.ProjectX.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Altkom.Merrid.ProjectX.DbServices
{
    // PM> Install-Package Microsoft.EntityFrameworkCore

    // Migracje:
    // PM> Install-Package Microsoft.EntityFrameworkCore.Tools.DotNet
    public class ProjectXContext : DbContext
    {
        public DbSet<Meter> Meters { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Unit> Units { get; set; }


        public ProjectXContext(DbContextOptions<ProjectXContext> options)
            : base(options)
        {

            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MeterConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
