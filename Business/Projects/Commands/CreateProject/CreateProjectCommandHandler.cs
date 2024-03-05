using Business.Interfaces;
using Domain.Models;
using MediatR;

namespace Business.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler 
        :IRequestHandler <CreateProjectCommand, int>
    {
        private readonly IDataDbContext _dbContext;

        public CreateProjectCommandHandler(IDataDbContext dbContext) =>  _dbContext = dbContext; 
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                ProjectManagerId = request.ProjectManagerId,
                Name = request.Name,
                NameCustomer = request.NameCustomer,
                NameContractor = request.NameContractor,
                DateBeginning = request.DateBeginning,
                DateEnd = request.DateEnd,
                Priority = request.Priority
            };

            await _dbContext.Projects.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
