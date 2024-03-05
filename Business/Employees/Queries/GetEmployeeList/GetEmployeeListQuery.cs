using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Projects.Queries.GetProjectList;
using MediatR;

namespace Business.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery :IRequest<EmployeeListVm>
    {
    }
}
