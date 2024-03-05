using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery,ProjectListVm>
    {
        private readonly IDataDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectListQueryHandler(IDataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = await _dbContext.Projects
                .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projectsQuery };
        }
    }
}
