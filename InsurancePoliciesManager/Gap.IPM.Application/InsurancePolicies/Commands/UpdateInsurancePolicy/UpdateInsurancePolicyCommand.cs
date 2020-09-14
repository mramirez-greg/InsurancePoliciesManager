using Gap.IPM.Application.Common.Exceptions;
using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using Gap.IPM.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.InsurancePolicies.Commands.UpdateInsurancePolicy
{
    public class UpdateInsurancePolicyCommand : IRequest
    {
        public long InsurancePolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoverageTypeId { get; set; }
        public int Coverage { get; set; }
        public DateTime CoverageStart { get; set; }
        public int CoveragePeriod { get; set; }
        public long PolicyValue { get; set; }
        public RiskType RiskType { get; set; }
    }
    public class UpdateInsurancePolicyCommandHandler : IRequestHandler<UpdateInsurancePolicyCommand>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        public UpdateInsurancePolicyCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateInsurancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.InsurancePolicy.FindAsync(request.InsurancePolicyId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(InsurancePolicy), request.InsurancePolicyId);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.CoverageTypeId = request.CoverageTypeId;
            entity.Coverage = request.Coverage/100;
            entity.CoverageStart = request.CoverageStart;
            entity.CoveragePeriod = request.CoveragePeriod;
            entity.PolicyValue = request.PolicyValue;
            entity.RiskType = request.RiskType;
            entity.IsActive = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
