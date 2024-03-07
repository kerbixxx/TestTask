using Data.Enums;
using MediatR;

namespace Business.ProjectTasks.Commands.CreateProjectTask
{
    public class CreateProjectTaskCommand : IRequest<int>
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string AuthorId { get; set; }
        public string? ExecutorId { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
