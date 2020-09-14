using Gap.IPM.Application.CustomersInsurancePolicies.Commands.CreateCustomerInsurancePolicy;
using Gap.IPM.Application.CustomersInsurancePolicies.Commands.UpdateCustomerInsurancePolicy;
using Gap.IPM.Application.CustomersInsurancePolicies.Queries.GetCustomerInsurancePolicy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gap.IPM.WebUI.Controllers
{
    public class CustomersInsurancePoliciesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<CustomerInsurancePolicyListVm>> Get()
        {
            return await Mediator.Send(new GetCustomerInsurancePolicyListQuery());
        }


        [HttpPost]
        public async Task<ActionResult<Int64>> Create(CreateCustomerInsurancePolicyCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Int64 id, UpdateCustomerInsurancePolicyCommand command)
        {
            if (id != command.CustomerInsurancePolicyId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
