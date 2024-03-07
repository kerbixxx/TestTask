using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.ProjectTasks.Commands.ReassignProjectTask
{
    public class ReassignProjectTaskCommandHandler : IRequestHandler<ReassignProjectTaskCommand>
    {
        private readonly IDataDbContext _dbContext;

        public ReassignProjectTaskCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(ReassignProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var projectTask = await _dbContext.ProjectTasks.FirstOrDefaultAsync(pt => pt.Id == request.TaskId);
            if (projectTask == null)
            {
                throw new NotFoundException(nameof(ProjectTask), request.TaskId);
            }

            var executor = await _dbContext.Employees.FirstOrDefaultAsync(executor => executor.Id == request.ExecutorId);
            if (executor == null)
            {
                throw new NotFoundException(nameof(Employee), request.ExecutorId);
            }

            projectTask.ExecutorId = executor.Id;
            _dbContext.ProjectTasks.Update(projectTask);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
