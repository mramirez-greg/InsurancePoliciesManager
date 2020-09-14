using Gap.IPM.Application.Customers.Commands.CreateCustomer;
using Gap.IPM.Application.Customers.Commands.UpdateCustomer;
using Gap.IPM.Application.Customers.Queries.GetCustomer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gap.IPM.WebUI.Controllers
{

    public class CustomerController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<CustomersListVm>> Get()
        {
            return await Mediator.Send(new GetCustomerListQuery());
        }


        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateCustomerCommand command)
        {
            if (id != command.CustomerId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
