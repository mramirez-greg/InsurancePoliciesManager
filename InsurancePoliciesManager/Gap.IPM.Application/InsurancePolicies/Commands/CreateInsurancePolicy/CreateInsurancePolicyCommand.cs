using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using Gap.IPM.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.InsurancePolicies.Commands.CreateInsurancePolicy
{
    public class CreateInsurancePolicyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoverageTypeId { get; set; }
        public int Coverage { get; set; }
        public DateTime CoverageStart { get; set; }
        public int CoveragePeriod { get; set; }
        public Int64 PolicyValue { get; set; }
        public RiskType RiksType { get; set; }
    }
    public class CreateInsurancePolicyCommandHandler : IRequestHandler<CreateInsurancePolicyCommand, int>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;

        public CreateInsurancePolicyCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInsurancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = new InsurancePolicy
            {
                Name = request.Name,
                Description = request.Description,
                CoverageTypeId=request.CoverageTypeId,
                Coverage=request.Coverage,
                CoverageStart=request.CoverageStart,
                CoveragePeriod=request.CoveragePeriod,
                PolicyValue=request.PolicyValue,
                RiksType=request.RiksType,
                IsActive=true
            };

            _context.InsurancePolicy.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.CoverageTypeId;
        }

    }
}
