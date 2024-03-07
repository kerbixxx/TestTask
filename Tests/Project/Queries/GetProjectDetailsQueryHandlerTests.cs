using AutoMapper;
using Business.Projects.Queries.GetProjectDetails;
using Data.Context;
using Shouldly;
using Tests.Common;

namespace Tests.Project.Queries
{
    [Collection("QueryCollection")]
    public class GetProjectDetailsQueryHandlerTests
    {
        private readonly DataDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectDetailsQueryHandler_Success()
        {
            var handler = new GetProjectDetailsQueryHandler(Context, Mapper);
            var result = await handler.Handle(
                new GetProjectDetailsQuery()
                {
                    Id = 1
                }, CancellationToken.None);

            result.ShouldBeOfType<ProjectDetailsVm>();
            result.Name.ShouldBe("Проект 1");
        }
    }
}
