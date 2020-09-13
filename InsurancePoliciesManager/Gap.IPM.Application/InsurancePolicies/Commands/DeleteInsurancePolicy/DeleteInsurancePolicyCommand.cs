using Gap.IPM.Application.Common.Exceptions;
using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Gap.IPM.Application.InsurancePolicies.Commands.DeleteInsurancePolicy
{
    public class DeleteInsurancePolicyCommand : IRequest
    {
        public Int64 InsurancePolicyId { get; set; }
    }
    public class DeleteInsurancePolicyCommandHandler : IRequestHandler<DeleteInsurancePolicyCommand>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;
        public DeleteInsurancePolicyCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteInsurancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.InsurancePolicy.FindAsync(request.InsurancePolicyId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(InsurancePolicy), request.InsurancePolicyId);
            }
            // delete is not posible for database integrity reasons, set value to false
            entity.IsActive = false;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
