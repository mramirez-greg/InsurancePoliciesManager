using MediatR;

namespace Gap.IPM.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerListQuery : IRequest<CustomersListVm>
    {
    }
}
