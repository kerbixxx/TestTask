using MediatR;

namespace Business.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public int ProjectManagerId { get; set; }
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string NameContractor { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public int Priority { get; set; }
    }
}
