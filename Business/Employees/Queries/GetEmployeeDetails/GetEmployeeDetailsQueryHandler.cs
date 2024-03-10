using AutoMapper;
using Business.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Business.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery,EmployeeDetailsVm>
    {
        private readonly IDataDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsQueryHandler(IDataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request,CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees.Include(p => p.Projects)
                .FirstOrDefaultAsync(employee => employee.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee),request.Id);
            }

            return _mapper.Map<EmployeeDetailsVm>(entity);
        }
    }
}
