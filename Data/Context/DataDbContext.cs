using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;

namespace Data.Context
{
    public class DataDbContext : IdentityDbContext<IdentityUser>, IDataDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Sibers.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            builder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.Employees)
                .HasForeignKey(pe => pe.ProjectId);

            builder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Employee)
                .WithMany(e => e.Projects)
                .HasForeignKey(pe => pe.EmployeeId);

            builder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // Настройка поведения при удалении менеджера проекта



            const string ROLE_ID_ADMIN = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID_MANAGER = "ad376a8f-9eab-4bb9-9fca-30b01540f445";
            const string ROLE_ID_EMPLOYEE = "bd17-00bd9344e575-a18be9c0-9eab-4bb9-f445";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ROLE_ID_ADMIN, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = ROLE_ID_MANAGER, Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = ROLE_ID_EMPLOYEE, Name = "Employee", NormalizedName = "EMPLOYEE" }
            );

        }
    }
}
