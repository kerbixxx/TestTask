using MediatR;

namespace Business.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public string Id { get; set; }
    }
}
