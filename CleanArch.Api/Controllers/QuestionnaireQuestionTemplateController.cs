using Application.Cqrs.Feedbacks.QuestionnaireQuestionTemplate.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/questionnaireQuestionTemplate")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class QuestionnaireQuestionTemplateController : ApiControllerBase
    {
        /// <summary>
        /// Metodo que retorna todas las preguntas por tipo de plan de acompañamiento
        /// </summary>
        /// <param name="typeAccompanimentPlanId"></param>
        /// <returns></returns>
        [HttpGet("typeAccompanimentPlanId/{typeAccompanimentPlanId}")]
        public async Task<IActionResult> GetByTypeAccompanimentPlanIdQuestionnaireQuestion(int typeAccompanimentPlanId)
        {
            return Ok(await Mediator.Send(new GetByTypeAccompanimentPlanIdQuestionnaireQuestionPlanQuery { TypeAccompanimentPlanId = typeAccompanimentPlanId }));
        }
    }
}