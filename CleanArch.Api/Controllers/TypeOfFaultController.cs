using Application.Cqrs.AdministrativeProcesses.TypeOfFaults.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/typeoffault")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "AdministrativeProcesses")]
    public class TypeOfFaultController : ApiControllerBase
    {

        /// <summary>
        /// Metodo que retorna el listado de todas las faltas del proceso administrativo
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTypeOfFautl([FromQuery] GetTypeOfFaultQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
