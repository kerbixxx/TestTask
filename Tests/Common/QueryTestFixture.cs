using AutoMapper;
using Business.Common.Mappings;
using Data.Context;
using Data.Interfaces;

namespace Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public DataDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = DataContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IDataDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            DataContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>{}
}
