using Business.Common.Exceptions;
using Business.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.ProjectTasks.Commands.UpdateProjectTask
{
    public class UpdateProjectTaskCommandHandler : IRequestHandler<UpdateProjectTaskCommand>
    {
        private readonly IDataDbContext _dbContext;

        public UpdateProjectTaskCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(UpdateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ProjectTasks.FirstOrDefaultAsync(pt => pt.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectTask), request.Id);
            }
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Status = request.Status;
            entity.Priority = request.Priority;

            _dbContext.ProjectTasks.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
