using Application.Cqrs.Feedbacks.ResponseQuestion.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/responseQuestion")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class ResponseQuestionController : ApiControllerBase
    {
        /// <summary>
        /// Retorna las respuestas a las preguntas de un plan de acompañamiento
        /// </summary>
        /// <param name="responseAccompanimentPlanId"></param>
        /// <returns></returns>
        [HttpGet("responseaccompanimentplanid/{responseAccompanimentPlanId}")]
        public async Task<IActionResult> GetByResponseAccompanimentPlanIdResponseQuestion(int responseAccompanimentPlanId)
        {
            return Ok(await Mediator.Send(new GetByResponseAccompanimentPlanIdResponseQuestionQuery { ResponseAccompanimentPlanId = responseAccompanimentPlanId }));
        }
        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] PostResponseQuestionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }*/
    }
}
