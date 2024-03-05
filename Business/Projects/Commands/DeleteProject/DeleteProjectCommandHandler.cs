using Business.Common.Exceptions;
using Business.Interfaces;
using Domain.Models;
using MediatR;

namespace Business.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler :IRequestHandler<DeleteProjectCommand>
    {
        private readonly IDataDbContext _dbContext;

        public DeleteProjectCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects.FindAsync(request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
