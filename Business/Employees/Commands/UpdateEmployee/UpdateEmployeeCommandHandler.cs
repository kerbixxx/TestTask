using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IDataDbContext _dbContext;
        private readonly UserManager<Employee> _userManager;
        public UpdateEmployeeCommandHandler(IDataDbContext dbContext, UserManager<Employee> userManager) => (_dbContext,_userManager) = (dbContext,userManager);

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == request.Id,
                    cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            if (entity.Email != request.Email)
            {
                await _userManager.SetEmailAsync(entity, request.Email);
                var emailConfirmationToken = await _userManager.GenerateChangeEmailTokenAsync(entity,request.Email);
                await _userManager.ConfirmEmailAsync(entity, emailConfirmationToken);
                entity.UserName = request.Email;
                entity.NormalizedEmail = request.Email.Normalize();
                entity.NormalizedUserName = request.Email.Normalize();
            }
            entity.Name = request.Name;
            entity.SecondName = request.SecondName;
            entity.Patronymic = request.Patronymic;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
