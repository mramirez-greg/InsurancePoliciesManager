using AutoMapper;
using Gap.IPM.Application.Customers.Queries.GetCustomer;
using Gap.IPM.ApplicationUnitTest.Common;
using Gap.IPM.Infrastructure.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Gap.IPM.ApplicationUnitTest.Customer.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerQueryHandlerTests
    {
        private readonly ApplicationInsurancePolicyDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCustomers()
        {
            var sut = new GetCustomerListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomerListQuery {}, CancellationToken.None);

            result.ShouldBeOfType<CustomersListVm>();

        }
    }
}
