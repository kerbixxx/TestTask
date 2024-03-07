using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.ProjectTasks.Commands.DeleteProjectTask
{
    public class DeleteProjectTaskCommandHandler : IRequestHandler<DeleteProjectTaskCommand>
    {
        private readonly IDataDbContext _dbContext;

        public DeleteProjectTaskCommandHandler(IDataDbContext dbContext)=>_dbContext = dbContext;

        public async Task Handle(DeleteProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProjectTasks.FirstOrDefaultAsync(pt => pt.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectTask), request.Id);
            }

            _dbContext.ProjectTasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
