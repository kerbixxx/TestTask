using Business.Common.Exceptions;
using Business.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.ProjectTasks.Commands.CreateProjectTask
{
    public class CreateProjectTaskCommandHandler : IRequestHandler<CreateProjectTaskCommand,int>
    {
        private readonly IDataDbContext _dbContext;

        public CreateProjectTaskCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task<int> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var projectTask = new ProjectTask
            {
                ProjectId = request.ProjectId,
                Name = request.Name,
                AuthorId = request.AuthorId,
                ExecutorId = request.ExecutorId,
                Status = request.Status,
                Description = request.Description,
                Priority = request.Priority
            };

            var project =
                await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id == request.ProjectId,
                    cancellationToken);

            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            var author =
                await _dbContext.Employees.FirstOrDefaultAsync(author => author.Id == request.AuthorId,
                    cancellationToken);

            if (author == null)
            {
                throw new NotFoundException(nameof(Employee), request.AuthorId);
            }

            var executor =
                await _dbContext.Employees.FirstOrDefaultAsync(executor => executor.Id == request.ExecutorId,
                    cancellationToken);

            if (author == null)
            {
                throw new NotFoundException(nameof(Employee), request.ExecutorId);
            }

            await _dbContext.ProjectTasks.AddAsync(projectTask,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return projectTask.Id;
        }
    }
}
