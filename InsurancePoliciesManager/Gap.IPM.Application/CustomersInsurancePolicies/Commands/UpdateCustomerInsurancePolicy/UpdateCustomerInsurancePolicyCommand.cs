using Gap.IPM.Application.Common.Exceptions;
using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using Gap.IPM.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.CustomersInsurancePolicies.Commands.UpdateCustomerInsurancePolicy
{
    public class UpdateCustomerInsurancePolicyCommand : IRequest<Int64>
    {
        public Int64 CustomerInsurancePolicyId { get; set; }
        public CustomerInsurancePolicyStatus Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
    public class UpdateCustomerInsurancePolicyCommanddHandler : IRequestHandler<UpdateCustomerInsurancePolicyCommand, Int64>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;

        public UpdateCustomerInsurancePolicyCommanddHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<Int64> Handle(UpdateCustomerInsurancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CustomerInsurancePolicy.FindAsync(request.CustomerInsurancePolicyId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomerInsurancePolicy), request.CustomerInsurancePolicyId);
            }

            entity.Status = request.Status;
            entity.StatusDate = request.StatusDate;
           

            await _context.SaveChangesAsync(cancellationToken);

            return entity.CustomerInsurancePolicyId;
        }

    }
}
