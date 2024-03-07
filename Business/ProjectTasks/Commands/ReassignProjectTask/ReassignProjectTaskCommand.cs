using MediatR;

namespace Business.ProjectTasks.Commands.ReassignProjectTask
{
    public class ReassignProjectTaskCommand : IRequest
    {
        public int TaskId { get; set; }
        public int ExecutorId { get; set; }
    }
}
