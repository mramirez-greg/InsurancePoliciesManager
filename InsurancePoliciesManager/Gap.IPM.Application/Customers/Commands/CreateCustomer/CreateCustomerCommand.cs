using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<string>
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
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
    {
        private readonly IApplicationInsurancePolicyDbContext _context;

        public CreateCustomerCommandHandler(IApplicationInsurancePolicyDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                CustomerId = request.CustomerId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Phone = request.Phone,
                City = request.City,
                Region = request.Region,
                Country = request.Country,
                PostalCode = request.PostalCode
            };

            _context.Customer.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.CustomerId;
        }

    }
}
