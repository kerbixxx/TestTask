using MediatR;

namespace Business.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public string Id { get; set; }
    }
}
