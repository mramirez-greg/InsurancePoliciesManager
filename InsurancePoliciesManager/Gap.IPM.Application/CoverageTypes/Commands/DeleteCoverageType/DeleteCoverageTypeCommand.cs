using Gap.IPM.Application.Common.Exceptions;
using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.CoverageTypes.Commands.DeleteCoverageType
{
    public class DeleteCoverageTypeCommand : IRequest
    {
        public int CoverageTypeId { get; set; }
    }
    public class DeleteCoverageTypeCommandHandler : IRequestHandler<DeleteCoverageTypeCommand>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        public DeleteCoverageTypeCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCoverageTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CoverageType.FindAsync(request.CoverageTypeId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CoverageType), request.CoverageTypeId);
            }
            //delete is not posible for database integrity reasons, set value to false
            entity.IsActive = false;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
