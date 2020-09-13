using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gap.IPM.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.InsurancePolicies.Queries.GetInsurancePolicies
{
    public class GetInsurancePoliciesListQueryHandler : IRequestHandler<GetInsurancePoliciesListQuery, InsurancePoliciesListVm>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        private readonly IMapper _mapper;

        public GetInsurancePoliciesListQueryHandler(IApplicationInsurancePolicyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InsurancePoliciesListVm> Handle(GetInsurancePoliciesListQuery request, CancellationToken cancellationToken)
        {
            var insurancePolicy = await _context.InsurancePolicy.Where(item => item.IsActive).Include(item=>item.CoverageType)
                .ProjectTo<InsurancePolicyLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new InsurancePoliciesListVm
            {
                InsurancePolicies = insurancePolicy
            };

            return vm;
        }
    }
}
