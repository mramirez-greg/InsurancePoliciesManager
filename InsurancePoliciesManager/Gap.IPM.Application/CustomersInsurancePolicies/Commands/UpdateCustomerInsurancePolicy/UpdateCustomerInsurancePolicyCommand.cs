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
    }
    public class UpdateCustomerInsurancePolicyCommanddHandler : IRequestHandler<UpdateCustomerInsurancePolicyCommand, Int64>
    {
        private readonly IApplicationInsurancePolicyDbContext _context; 
        private readonly IDateTime _dateTime;

        public UpdateCustomerInsurancePolicyCommanddHandler(IApplicationInsurancePolicyDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<Int64> Handle(UpdateCustomerInsurancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CustomerInsurancePolicy.FindAsync(request.CustomerInsurancePolicyId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomerInsurancePolicy), request.CustomerInsurancePolicyId);
            }

            entity.Status = request.Status;
            entity.StatusDate =_dateTime.Now;
           

            await _context.SaveChangesAsync(cancellationToken);

            return entity.CustomerInsurancePolicyId;
        }

    }
}
