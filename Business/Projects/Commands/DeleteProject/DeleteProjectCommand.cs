using MediatR;

namespace Business.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
