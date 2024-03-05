using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery,EmployeeListVm>
    {
        private readonly IDataDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEmployeeListQueryHandler(IDataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeListVm> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeeQuery = await _dbContext.Employees
                .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListVm { Employees = employeeQuery };
        }
    }
}
