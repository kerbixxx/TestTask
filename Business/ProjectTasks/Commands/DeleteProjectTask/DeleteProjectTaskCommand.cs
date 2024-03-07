using MediatR;

namespace Business.ProjectTasks.Commands.DeleteProjectTask
{
    public class DeleteProjectTaskCommand : IRequest
    {
        public int Id { get; set; }
    }
}
