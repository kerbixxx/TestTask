using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

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

            _dbContext.ProjectEmployees.Add(new ProjectEmployee(){EmployeeId = request.EmployeeId,ProjectId = request.ProjectId});
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
