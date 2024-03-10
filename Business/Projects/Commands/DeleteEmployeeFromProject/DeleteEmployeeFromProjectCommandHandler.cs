using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
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
            // Проверка наличия проекта и сотрудника
            var project = await _dbContext.Projects.FindAsync(request.ProjectId);
            var employee = await _dbContext.Employees.FindAsync(request.EmployeeId);

            if (project == null || employee == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId)
                      ?? new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            // Удаление связи через промежуточную таблицу
            var projectEmployee = await _dbContext.ProjectEmployees
                .FirstOrDefaultAsync(pe => pe.ProjectId == request.ProjectId && pe.EmployeeId == request.EmployeeId, cancellationToken);

            if (projectEmployee != null)
            {
                _dbContext.ProjectEmployees.Remove(projectEmployee);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Employee),request.EmployeeId);
            }
        }
    }
}
