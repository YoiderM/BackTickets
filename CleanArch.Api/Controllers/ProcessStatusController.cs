using Application.Cqrs.AdministrativeProcesses.ProcessStates.Queries;
using ClaroFidelizacion.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{

    [Route("api/processstatus")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "AdministrativeProcesses")]
    public class ProcessStatusController : ApiControllerBase
    {
        /// <summary>
        /// Método que retorna los todos los estados
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProcessStates([FromQuery] GetProcessStatesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
