using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_09_additionalTask_1
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R3LQDV9;Database = testDB1;Trusted_Connection =True;TrustServerCertificate=True") ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasOne(e => e.Company)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.CompanyId);


            modelBuilder.Entity<Project>().HasMany(e => e.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity(e => e.ToTable("EmployeeProjects"));
        }
    }
}


