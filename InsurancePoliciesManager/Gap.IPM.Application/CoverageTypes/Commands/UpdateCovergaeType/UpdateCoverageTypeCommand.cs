using Gap.IPM.Application.Common.Exceptions;
using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.CoverageTypes.Commands.UpdateCovergaeType
{
    public class UpdateCoverageTypeCommand: IRequest
    {
        public int CovergaeTypeId { get; set; }
        public String CoverageTypeName { get; set; }

    }
    public class UpdateCoverageTypeCommandHandler : IRequestHandler<UpdateCoverageTypeCommand>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        public UpdateCoverageTypeCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCoverageTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CoverageType.FindAsync(request.CovergaeTypeId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CoverageType), request.CovergaeTypeId);
            }

            entity.CoverageTypeName = request.CoverageTypeName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
