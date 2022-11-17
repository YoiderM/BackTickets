using Application.Cqrs.Feedbacks.ResponseAdditionalQuestion.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/responseAdditionalQuestion")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class ResponseAdditionalQuestionController : ApiControllerBase
    {
        /// <summary>
        /// Retorna las respuestas de las preguntas adicionales de un plan de acompañamiento
        /// </summary>
        /// <param name="responseAccompanimentPlanId"></param>
        /// <returns></returns>
        [HttpGet("responseaccompanimentplanid/{responseAccompanimentPlanId}")]
        public async Task<IActionResult> GetByResponseAccompanimentPlanIdResponseAdditionalQuestion(int responseAccompanimentPlanId)
        {
            return Ok(await Mediator.Send(new GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQuery { ResponseAccompanimentPlanId = responseAccompanimentPlanId }));
        }
        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] PostResponseAdditionalQuestionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }*/
    }
}
