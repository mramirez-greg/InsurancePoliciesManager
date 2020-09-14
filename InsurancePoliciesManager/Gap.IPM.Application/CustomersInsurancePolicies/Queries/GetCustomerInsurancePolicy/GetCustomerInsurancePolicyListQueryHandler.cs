using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gap.IPM.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.CustomersInsurancePolicies.Queries.GetCustomerInsurancePolicy
{
    public class GetCustomerInsurancePolicyListQueryHandler : IRequestHandler<GetCustomerInsurancePolicyListQuery, CustomerInsurancePolicyListVm>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerInsurancePolicyListQueryHandler(IApplicationInsurancePolicyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<CustomerInsurancePolicyListVm> Handle(GetCustomerInsurancePolicyListQuery request, CancellationToken cancellationToken)
        {
            var customerInsurancePolicies = await _context.CustomerInsurancePolicy
                .Include(item=>item.Customer)
                .Include(item=>item.InsurancePolicy)
                .ProjectTo<CustomerInsurancePolicyLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CustomerInsurancePolicyListVm
            {
                CustomerInsurancePolicies= customerInsurancePolicies
            };

            return vm;
        }
    }
}
