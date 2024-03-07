using AutoMapper;
using Business.Projects.Queries.GetProjectList;
using Data.Context;
using Shouldly;
using Tests.Common;

namespace Tests.Project.Queries
{
    [Collection("QueryCollection")]
    public class GetProjectListQueryHandlerTests
    {
        private readonly DataDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectListQueryHandler_Success()
        {
            var handler = new GetProjectListQueryHandler(Context, Mapper);
            var result = await handler.Handle(
                new GetProjectListQuery()
                {

                }, CancellationToken.None);
            result.ShouldBeOfType<ProjectListVm>();
            result.Projects.Count.ShouldBe(2);
        }
    }
}
