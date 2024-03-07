using MediatR;

namespace Business.Projects.Commands.DeleteEmployeeFromProject
{
    public class DeleteEmployeeFromProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
        public string EmployeeId { get; set; }
    }
}
