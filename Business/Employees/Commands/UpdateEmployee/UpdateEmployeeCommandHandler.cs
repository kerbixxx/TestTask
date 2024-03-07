using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IDataDbContext _dbContext;
        public UpdateEmployeeCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == request.Id,
                    cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            entity.Email = request.Email;
            entity.Name = request.Name;
            entity.SecondName = request.SecondName;
            entity.Patronymic = request.Patronymic;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
