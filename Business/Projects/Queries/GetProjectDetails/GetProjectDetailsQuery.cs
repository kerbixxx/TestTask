using MediatR;

namespace Business.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery :IRequest<ProjectDetailsVm>
    {
        public int Id { get; set; }
    }
}
