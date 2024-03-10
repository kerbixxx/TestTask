using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IDataDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectTask> ProjectTasks { get; set; }
        DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken  cancellationToken);
    }
}
