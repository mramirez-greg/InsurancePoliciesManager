﻿using Gap.IPM.Application.Common.Exceptions;
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
        public int InsurancePolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoverageTypeId { get; set; }
        public int Coverage { get; set; }
        public string CoverageStart { get; set; }
        public int CoveragePeriod { get; set; }
        public int PolicyValue { get; set; }
        public int RiskType { get; set; }
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
            entity.Coverage = request.Coverage;
            entity.CoverageStart =DateTime.Parse(request.CoverageStart);
            entity.CoveragePeriod = request.CoveragePeriod;
            entity.PolicyValue = request.PolicyValue;
            entity.RiskType = request.RiskType;
            entity.IsActive = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
