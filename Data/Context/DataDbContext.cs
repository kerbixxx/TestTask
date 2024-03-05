using Business.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataDbContext : DbContext, IDataDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = Sibers.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>()
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects);

            base.OnModelCreating(builder);
        }
    }
}
