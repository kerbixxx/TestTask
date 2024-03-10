using MediatR;

namespace Business.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery :IRequest<EmployeeListVm>
    {
    }
}
