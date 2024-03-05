using Business.Interfaces;
using Domain.Models;
using MediatR;

namespace Business.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand,int>
    {
        private readonly IDataDbContext _dbContext;
        public CreateEmployeeCommandHandler(IDataDbContext dbContext) => _dbContext = dbContext;
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                SecondName = request.SecondName,
                Patronymic = request.Patronymic,
                Email = request.Email,
            };

            await _dbContext.Employees.AddAsync(employee,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
