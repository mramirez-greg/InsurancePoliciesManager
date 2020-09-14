using AutoMapper;
using Gap.IPM.Application.Common.Mappings;
using Gap.IPM.Infrastructure.Persistence;
using System;
using Xunit;

namespace Gap.IPM.ApplicationUnitTest.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ApplicationInsurancePolicyDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = IPMDabaseContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            IPMDabaseContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
