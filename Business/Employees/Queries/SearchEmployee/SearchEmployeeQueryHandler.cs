using AutoMapper;
using Business.Employees.Queries.GetEmployeeList;
using Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Employees.Queries.SearchEmployee
{
    public class SearchEmployeeQueryHandler : IRequestHandler<SearchEmployeeQuery,IEnumerable<EmployeeListVm>>
    {
        private readonly IDataDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchEmployeeQueryHandler(IDataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeListVm>> Handle(SearchEmployeeQuery request,
            CancellationToken cancellationToken)
        {
            var employees = await _dbContext.Employees
                .Where(e => e.Name.Contains(request.Query) || e.SecondName.Contains(request.Query) ||
                            e.Patronymic.Contains(request.Query)).ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<EmployeeListVm>>(employees);
        }
    }
}
