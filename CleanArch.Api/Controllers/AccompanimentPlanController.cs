using Application.Cqrs.Feedbacks.AccompanimentPlan.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/accompanimentPlan")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class AccompanimentPlanController : ApiControllerBase
    {
        /// <summary>
        /// Método que retorna todos los Planes de acompañamiento existentes en el sistema.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetResponseAccompanimentPlanQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Metodo que retorna todos los Planes de Acompañamiento por Tipo de plan de acompañamiento
        /// </summary>
        /// <param name="typeAccompanimentPlanId"></param>
        /// <returns></returns>
        [HttpGet("typeAccompanimentPlan/{typeAccompanimentPlanId}")]
        public async Task<IActionResult> GetByTypeAccompanimentPlanId(int typeAccompanimentPlanId)
        {
            return Ok(await Mediator.Send(new GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery { TypeAccompanimentPlanId = typeAccompanimentPlanId }));
        }
        /// <summary>
        /// Metodo que retorna todos los Planes de Acompañamiento por documento
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpGet("document/{document}")]
        public async Task<IActionResult> GetByDocumentAccompanimentPlanId(string document)
        {
            return Ok(await Mediator.Send(new GetByDocumentResponseAccompanimentPlanQuery { Document = document }));
        }
        /// <summary>
        /// Metodo que retorna todos los Planes de Acompañamiento por estado
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetByStatusIdAccompanimentPlanId(Guid statusId)
        {
            return Ok(await Mediator.Send(new GetByStatusIdResponseAccompanimentPlanQuery { StatusId = statusId }));
        }
    }
}
