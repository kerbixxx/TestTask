using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.ProjectTasks.Queries.GetProjectTaskList
{
    public class GetProjectTaskListQueryHandler : IRequestHandler<GetProjectTaskListQuery,ProjectTaskListVm>
    {
        private readonly IDataDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectTaskListQueryHandler(IDataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProjectTaskListVm> Handle(GetProjectTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.ProjectTasks.AsQueryable();

            // Фильтрация
            if (request.AuthorId.HasValue)
            {
                query = query.Where(t => t.AuthorId == request.AuthorId.Value);
            }
            if (request.ExecutorId.HasValue)
            {
                query = query.Where(t => t.ExecutorId == request.ExecutorId.Value);
            }
            if (request.Status.HasValue)
            {
                query = query.Where(t => t.Status == request.Status.Value);
            }
            if (request.Priority.HasValue)
            {
                query = query.Where(t => t.Priority == request.Priority.Value);
            }

            // Сортировка
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var parameter = Expression.Parameter(typeof(ProjectTask), "p");
                var property = Expression.Property(parameter, request.SortBy);
                var lambda = Expression.Lambda<Func<ProjectTask, object>>(Expression.Convert(property, typeof(object)), parameter);

                if (request.SortOrder == "asc")
                {
                    query = query.OrderBy(lambda);
                }
                else
                {
                    query = query.OrderByDescending(lambda);
                }
            }

            var projectTasks = await query.ProjectTo<ProjectTaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectTaskListVm { ProjectTasks = projectTasks };
        }
    }
}
