using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Common.Exceptions;
using Business.Interfaces;
using Domain.Models;
using MediatR;

namespace Business.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IDataDbContext _dbContext;
        public DeleteEmployeeCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
