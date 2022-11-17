using Application.Cqrs.AdministrativeProcesses.HistoryChangeProcesses.Commands;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{

    [Route("api/processschangehistory")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "AdministrativeProcesses")]
    public class ProcessChangeHistoryController : ApiControllerBase
    {
        /// <summary>
        /// Metodo para insertar el historico de cada proceso disciplinario
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(PostChangeProcessHistoryCommand command)
        {
          return Ok(await Mediator.Send(command));

        }

    }
}
