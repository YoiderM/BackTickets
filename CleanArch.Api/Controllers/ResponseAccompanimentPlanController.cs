using Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Commands;
using Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/responseAccompanimentPlan")]
    [ApiController]
    //[Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class ResponseAccompanimentPlanController : ApiControllerBase
    {
        /// <summary>
        /// Método que retorna en que plan de acompañamiento se encuentra cada uno de los empleados (Por centro de costo autorizado al usuario logueado)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetResponseAccompanimentPlanQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Método que retorna todo el historial de planes de acompañamiento por tipo de plan de acompañamiento
        /// </summary>
        /// <param name="typeAccompanimentPlanid"></param>
        /// <returns></returns>
        [HttpGet("typeAccompanimentPlan/{typeAccompanimentPlanid}")]
        public async Task<IActionResult> GetByTypeAccompanimentPlanId(int typeAccompanimentPlanid)
        {
            return Ok(await Mediator.Send(new GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery { TypeAccompanimentPlanId = typeAccompanimentPlanid }));
        }
        /// <summary>
        /// Método que retorna todo el historial de planes de acompañamiento del empleado seleccionado
        /// </summary>
        /// <param name="accompanimentPlanId"></param>
        /// <returns></returns>
        [HttpGet("accompanimentPlan/{accompanimentPlanId}")]
        public async Task<IActionResult> GetByAccompanimentPlanId(int accompanimentPlanId)
        {
            return Ok(await Mediator.Send(new GetByAccompanimentPlanIdResponseAccompanimentPlanQuery { AccompanimentPlanId = accompanimentPlanId }));
        }
        /// <summary>
        /// Método que retorna todo el historial de planes de acompañamiento por documento
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpGet("document/{document}")]
        public async Task<IActionResult> GetByDocumentAccompanimentPlanId(string document)
        {
            return Ok(await Mediator.Send(new GetByDocumentResponseAccompanimentPlanQuery { Document = document }));
        }
        /// <summary>
        /// Metodo que guarda todas las respuestas, conclusiones, compromisos y fecha programada de proximo encuentro y crea el próximo plan de acompañamiento
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("endAccompanimentPlan")]
        public async Task<IActionResult> Post(PostResponseAccompanimentPlanCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /*[HttpGet("status/{statusid}")]
        public async Task<IActionResult> GetByStatusIdAccompanimentPlanId(Guid statusid)
        {
            return Ok(await Mediator.Send(new GetByStatusIdResponseAccompanimentPlanQuery { StatusId = statusid }));
        }*/
    }
}
