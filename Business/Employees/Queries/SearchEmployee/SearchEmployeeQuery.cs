using Business.Employees.Queries.GetEmployeeList;
using MediatR;

namespace Business.Employees.Queries.SearchEmployee
{
    public class SearchEmployeeQuery : IRequest<IEnumerable<EmployeeListVm>>
    {
        public string Query { get; set; }
    }

}
