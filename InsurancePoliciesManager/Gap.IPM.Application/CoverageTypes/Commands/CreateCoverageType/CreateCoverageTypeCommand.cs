using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.CoverageTypes.Commands.CreateCoverageType
{
    public class CreateCoverageTypeCommand : IRequest<int>
    {
        public String CoverageTypeName { get; set; }
       
    }
    public class CreateCoverageTypeCommandHandler : IRequestHandler<CreateCoverageTypeCommand, int>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;

        public CreateCoverageTypeCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCoverageTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new CoverageType
            {
                CoverageTypeName=request.CoverageTypeName,
                IsActive=true
            };

            _context.CoverageType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.CovergaeTypeId;
        }

    }
}
