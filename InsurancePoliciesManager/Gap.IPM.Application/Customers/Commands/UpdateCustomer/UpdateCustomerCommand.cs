using Gap.IPM.Application.Common.Exceptions;
using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<string>
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;

        public UpdateCustomerCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customer.FindAsync(request.CustomerId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.CustomerId);
            }

            entity.CustomerId = request.CustomerId;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Address = request.Address;
            entity.Phone = request.Phone;
            entity.City = request.City;
            entity.Region = request.Region;
            entity.Country = request.Country;
            entity.PostalCode = request.PostalCode;

     
            await _context.SaveChangesAsync(cancellationToken);

            return entity.CustomerId;
        }

    }
}
