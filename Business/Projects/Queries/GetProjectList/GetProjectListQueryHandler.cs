using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Business.Projects.Queries.GetProjectDetails;
using Data.Interfaces;
using Data.Models;

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
            var query = _dbContext.Projects.AsQueryable();

            if (request.StartDate.HasValue)
            {
                query = query.Where(p => p.DateBeginning >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                query = query.Where(p => p.DateEnd <= request.EndDate.Value);
            }

            if (request.Priority.HasValue)
            {
                query = query.Where(p => p.Priority == request.Priority.Value);
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var parameter = Expression.Parameter(typeof(Project), "p");
                var property = Expression.Property(parameter, request.SortBy);
                var lambda = Expression.Lambda<Func<Project, object>>(Expression.Convert(property, typeof(object)), parameter);

                if (request.SortOrder == "asc")
                {
                    query = query.OrderBy(lambda);
                }
                else
                {
                    query = query.OrderByDescending(lambda);
                }
            }

            var projectsQuery = await query
                .Include(p=>p.ProjectManager)
                .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProjectListVm { Projects = projectsQuery };
        }
    }
}
