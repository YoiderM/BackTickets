using Application.Cqrs.Resources.Commands;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/Resources")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Resources")]
    public class ResourcesController : ApiControllerBase
    {
        /// <summary>
        /// Post a resource from a Novelty
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("PostByNovelty")]
        public async Task<IActionResult> PostByNovelty ([FromForm] PostByNoveltyResourcesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
