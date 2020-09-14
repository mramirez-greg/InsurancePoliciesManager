using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using Gap.IPM.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.CustomersInsurancePolicies.Commands.CreateCustomerInsurancePolicy
{
    public class CreateCustomerInsurancePolicyCommand : IRequest<Int64>
    {
        public string CustomerId { get; set; }
        public Int64 InsurancePolicyId { get; set; }
        public CustomerInsurancePolicyStatus Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
    public class CreateCustomerInsurancePolicyCommandHandler : IRequestHandler<CreateCustomerInsurancePolicyCommand, Int64>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;

        public CreateCustomerInsurancePolicyCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<Int64> Handle(CreateCustomerInsurancePolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = new CustomerInsurancePolicy
            {
                CustomerId = request.CustomerId,
                InsurancePolicyId = request.InsurancePolicyId,
                Status = request.Status,
                StatusDate = request.StatusDate

            };

            _context.CustomerInsurancePolicy.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.CustomerInsurancePolicyId;
        }
    }
}
