﻿using Business.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Data.Context
{
    public class DataDbContext : DbContext, IDataDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
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
                .HasMany(e => e.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity(j => j.ToTable("ProjectEmployee"));

            builder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId);
            base.OnModelCreating(builder);
        }
    }
}
