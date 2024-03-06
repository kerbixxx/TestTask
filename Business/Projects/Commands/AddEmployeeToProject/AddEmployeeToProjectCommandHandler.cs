using Business.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Exceptions;
using Domain.Models;

namespace Business.Projects.Commands.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommandHandler : IRequestHandler<AddEmployeeToProjectCommand>
    {
        private readonly IDataDbContext _dbContext;
        public AddEmployeeToProjectCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(AddEmployeeToProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FindAsync(request.EmployeeId);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            var project = await _dbContext.Projects.FindAsync(request.ProjectId);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }
            project.Employees.Add(employee);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
