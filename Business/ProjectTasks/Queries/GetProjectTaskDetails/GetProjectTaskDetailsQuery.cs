using MediatR;

namespace Business.ProjectTasks.Queries.GetProjectTaskDetails
{
    public class GetProjectTaskDetailsQuery : IRequest<ProjectTaskDetailsVm>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
    }
}
