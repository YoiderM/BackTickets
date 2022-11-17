using Application.Cqrs.OvertimeTypes.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/OvertimeType")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "OvertimeType")]
    public class OvertimeTypeController : ApiControllerBase
    {
       

        /// <summary>
        /// Método que obtiene los tipos de Horas Extras
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetOvertimeTypesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

    }
}
