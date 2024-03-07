using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Interfaces
{
    public interface IDataDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectTask> ProjectTasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken  cancellationToken);
    }
}
