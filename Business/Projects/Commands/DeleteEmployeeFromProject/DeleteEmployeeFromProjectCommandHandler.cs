using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Exceptions;
using Business.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Projects.Commands.DeleteEmployeeFromProject
{
    public class DeleteEmployeeFromProjectCommandHandler : IRequestHandler<DeleteEmployeeFromProjectCommand>
    {
        private readonly IDataDbContext _dbContext;
        public DeleteEmployeeFromProjectCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteEmployeeFromProjectCommand request,CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            var project = await _dbContext.Projects.Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == request.ProjectId, cancellationToken);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            // Удаление ссылок на сотрудника из проекта и на проект у сотрудника
            project.Employees.Remove(employee);
            employee.Projects.Remove(project);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
