using Gap.IPM.Application.InsurancePolicies.Commands.CreateInsurancePolicy;
using Gap.IPM.Application.InsurancePolicies.Commands.DeleteInsurancePolicy;
using Gap.IPM.Application.InsurancePolicies.Commands.UpdateInsurancePolicy;
using Gap.IPM.Application.InsurancePolicies.Queries.GetInsurancePolicies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gap.IPM.WebUI.Controllers
{
    public class InsurancePolicyController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<InsurancePoliciesListVm>> Get()
        {
            return await Mediator.Send(new GetInsurancePoliciesListQuery());
        }
      

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateInsurancePolicyCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Int64 id, UpdateInsurancePolicyCommand command)
        {
            if (id != command.InsurancePolicyId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteInsurancePolicyCommand { InsurancePolicyId = id });

            return NoContent();
        }
    }
}
