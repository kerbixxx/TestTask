using MediatR;

namespace Business.Projects.Commands.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
        public string EmployeeId { get; set; }
    }
}
