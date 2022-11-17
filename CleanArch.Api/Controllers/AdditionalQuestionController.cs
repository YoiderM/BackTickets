using Application.Cqrs.Feedbacks.AdditionalQuestion.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/additionalQuestion")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class AdditionalQuestionController : ApiControllerBase
    {
        /// <summary>
        /// Método que retorna todos las preguntas adicionales preestablecidas
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAdditionalQuestion([FromQuery] GetAllAdditionalQuestionQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
