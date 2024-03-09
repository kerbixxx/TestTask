using System.Security.Cryptography;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand,string>
    {
        private readonly IDataDbContext _dbContext;
        private readonly UserManager<Employee> _userManager;
        public CreateEmployeeCommandHandler(IDataDbContext dbContext,
            UserManager<Employee> userManager) =>
            (_dbContext, _userManager) = (dbContext, userManager);
        public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name,
                SecondName = request.SecondName,
                Patronymic = request.Patronymic,
            };
            var password = "pass";
            var result = await _userManager.CreateAsync(employee, password);
            if (result.Succeeded)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                return $"ID = {employee.Id}; Password = {password}";
            }

            return "Не удалось создать нового сотрудника";

        }

        private static string GenerateRandomPassword()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[12];
                rng.GetBytes(bytes);

                // Преобразование байтов в символы ASCII для создания пароля
                var result = new char[bytes.Length];
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Добавление символов в диапазоне от 33 до 126 для создания видимых символов
                    result[i] = (char)(bytes[i] % (126 - 33) + 33);
                }

                return new string(result);
            }
        }
    }
}
