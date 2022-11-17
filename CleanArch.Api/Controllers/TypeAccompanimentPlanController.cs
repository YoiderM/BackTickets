using Application.Cqrs.Feedbacks.TypeAccompanimentPlan.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/typeAccompanimentPlan")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class TypeAccompanimentPlanController : ApiControllerBase
    {
        /// <summary>
        /// Método que retorna todos los tipos de plan de acompañamiento
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTypeAccompanimentPlan([FromQuery] GetTypeAccompanimentPlanQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Método que retorna la fecha inicial y final propuesta para el proximo plan de acompañamiento
        /// </summary>
        /// <param name="typeAccompanimentPlanId"></param>
        /// <returns></returns>
        [HttpGet("nextDateAccompanimentPlan/{typeAccompanimentPlanId}")]
        public async Task<IActionResult> GetNextDateAccompanimentPlan(int typeAccompanimentPlanId)
        {
            return Ok(await Mediator.Send(new GetNextDateByTypeAccompanimentPlanQuery { TypeAccompanimentPlanId = typeAccompanimentPlanId }));
        }
    }
}
