using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gap.IPM.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerListQueryHandler: IRequestHandler<GetCustomerListQuery, CustomersListVm>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IApplicationInsurancePolicyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CustomersListVm> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customer
                .ProjectTo<CustomersLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CustomersListVm
            {
                Customers = customers
            };

            return vm;
        }
    }
}
