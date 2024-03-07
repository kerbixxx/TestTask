using Domain.Enums;
using MediatR;

namespace Business.ProjectTasks.Queries.GetProjectTaskList
{
    public class GetProjectTaskListQuery : IRequest<ProjectTaskListVm>
    {
        public int? AuthorId { get; set; }
        public int? ExecutorId { get; set; }
        public Status? Status { get; set; }
        public int? Priority { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
    }
}
