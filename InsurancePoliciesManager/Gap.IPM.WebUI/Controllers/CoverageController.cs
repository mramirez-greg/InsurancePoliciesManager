using Gap.IPM.Application.CoverageTypes.Commands.CreateCoverageType;
using Gap.IPM.Application.CoverageTypes.Commands.DeleteCoverageType;
using Gap.IPM.Application.CoverageTypes.Commands.UpdateCovergaeType;
using Gap.IPM.Application.CoverageTypes.Queries.GetCoverageTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gap.IPM.WebUI.Controllers
{

    public class CoverageController : ApiController
    {
        // GET: api/<CreateCoverageController>
        [HttpGet]
        public async Task<ActionResult<CoverageTypesListVm>> Get()
        {
            return await Mediator.Send(new GetCoverageTypesListQuery());
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCoverageTypeCommand command)
        {
            return await Mediator.Send(command);
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCoverageTypeCommand command)
        {
            if (id != command.CovergaeTypeId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCoverageTypeCommand { CovergaeTypeId = id });

            return NoContent();
        }
    }
}
