using Domain.Enums;
using MediatR;

namespace Business.ProjectTasks.Commands.UpdateProjectTask
{
    public class UpdateProjectTaskCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
