using AutoMapper;
using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.ProjectTasks.Queries.GetProjectTaskDetails
{
    public class GetProjectTaskDetailsQueryHandler : IRequestHandler<GetProjectTaskDetailsQuery,ProjectTaskDetailsVm>
    {
        private readonly IDataDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectTaskDetailsQueryHandler(IDataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProjectTaskDetailsVm> Handle(GetProjectTaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ProjectTasks.FirstOrDefaultAsync(pt => pt.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectTask), request.Id);
            }

            return _mapper.Map<ProjectTaskDetailsVm>(entity);
        }
    }
}
