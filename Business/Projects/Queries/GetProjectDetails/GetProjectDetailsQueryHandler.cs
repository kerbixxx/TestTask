using AutoMapper;
using Business.Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler :IRequestHandler<GetProjectDetailsQuery,ProjectDetailsVm>
    {
        private readonly IDataDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectDetailsQueryHandler(IDataDbContext dbContext, IMapper mapper) => (_dbContext,_mapper) = (dbContext,mapper);

        public async Task<ProjectDetailsVm> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .FirstOrDefaultAsync(project => project.Id == request.Id,cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            return _mapper.Map<ProjectDetailsVm>(entity);
        }
    }
}
