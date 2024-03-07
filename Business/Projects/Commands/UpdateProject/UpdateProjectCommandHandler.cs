using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler :IRequestHandler<UpdateProjectCommand>
    {
        private readonly IDataDbContext _dbContext;

        public UpdateProjectCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;
        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Project),request.Id);
            }

            entity.Name = request.Name;
            entity.ProjectManagerId = request.ProjectManagerId;
            entity.NameCustomer = request.NameCustomer;
            entity.NameContractor = request.NameContractor;
            entity.DateBeginning = entity.DateBeginning;
            entity.DateEnd = entity.DateEnd;
            entity.Priority = entity.Priority;

            _dbContext.Projects.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
