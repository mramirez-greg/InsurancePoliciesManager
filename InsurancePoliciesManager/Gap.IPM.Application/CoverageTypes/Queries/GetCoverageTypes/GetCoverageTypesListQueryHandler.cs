using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gap.IPM.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.CoverageTypes.Queries.GetCoverageTypes
{
    public class GetCoverageTypesListQueryHandler : IRequestHandler<GetCoverageTypesListQuery, CoverageTypesListVm>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        private readonly IMapper _mapper;

        public GetCoverageTypesListQueryHandler(IApplicationInsurancePolicyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CoverageTypesListVm> Handle(GetCoverageTypesListQuery request, CancellationToken cancellationToken)
        {
            var coverageType = await _context.CoverageType.Where(item=>item.IsActive)
                .ProjectTo<CoverageTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CoverageTypesListVm
            {
                CoverageTypes = coverageType
            };

            return vm;
        }
    }
}
