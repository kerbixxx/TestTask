using MediatR;

namespace Business.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
    }
}
