using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands;
using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/disciplinaryprocess")]
    [ApiController]
    // [Authorize]
    [ApiExplorerSettings(GroupName = "AdministrativeProcesses")]
    public class DisciplinaryProcessController : ApiControllerBase
    {

        /// <summary>
        /// Método que permite crear una solicitud de proceso disciplinario.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PostDisciplinaryProcessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Método que permite guardar documentos relacionados con el proceso disciplinario
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("UploadfilePdf")]
        public async Task<IActionResult> PostFilePdf(IFormFile file)
        {
            return Ok(await Mediator.Send(new UploadFilePdfDisciplinaryProcessCommand { filePdf = file }));
        }

        /// <summary>
        /// Metodo retorna todas los procesos disciplinarios
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetDisciplinaryProcessQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo que obtiene los estados de los procesos recibe como parámetro el id del estado
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="idstatus"></param>
        /// <returns></returns>
        [HttpGet("{idstatus}")]
        public async Task<IActionResult> GetByStatus(int idstatus, DateTime startDate, DateTime endDate)
        {
            return Ok(await Mediator.Send(new GetByStatusDisciplinaryProcessQuery {StartDate = startDate, EndDate = endDate, ProcessStatusId = idstatus }));
        }

        /// <summary>
        /// Método que permite obtener las solicitudes creadas por el solicitante filtrado por estado y campaña (utilizado por el perfil que Autoriza los procesos)
        /// </summary>
        /// <param name="idstatus"></param>
        /// <param name="endDate"></param>
        /// <param name="idstatus"></param>
        /// <param name="costcenter"></param>

        /// <returns></returns>
        [HttpGet("{idstatus}/{costcenter}")]
        public async Task<IActionResult> GetByStatusAndUserC(int idstatus, string costcenter, DateTime startDate, DateTime endDate)
        {
            return Ok(await Mediator.Send(new GetByStatusAndCampaignDisciplinaryProcessQuery { ProcessStatusId = idstatus, CostCenter = costcenter, StartDate = startDate, EndDate = endDate}));

        }

        /// <summary>
        /// Método que obtiene las solicitudes creadas por el solicitante filtradas por estado y usuario de sesion (utilizado por el perfil que solicita los procesos)
        /// </summary>
        /// <param name="idstatus"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("Applicant/{idstatus}")]
        public async Task<IActionResult> GetByStatusAndUserId(int idstatus, DateTime startDate, DateTime endDate)
        {
            return Ok(await Mediator.Send(new GetByStatusAndCurrentUserIdDisciplinaryProcessQuery { ProcessStatusId = idstatus, StartDate = startDate, EndDate = endDate }));

        }
        /// <summary>
        /// Método que obtiene los procesos aprobados  filtrados por status y usuario de sesión (utiliza el perfil que aprueba el proceso)
        /// </summary>
        /// <param name="idstatus"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("Approving/{idstatus}")]
        public async Task<IActionResult> GetByStatusAndApproving(int idstatus, DateTime startDate, DateTime endDate)
        {
            return Ok(await Mediator.Send(new GetByStatusAndApprovingDisciplinaryProcessQuery { ProcessStatusId = idstatus, StartDate = startDate, EndDate = endDate }));

        }
        /// <summary>
        /// Método que obtiene los procesos autorizados filtrados por status y usuario de sesion (Utiliza el perfil que Autoriza el proceso)
        /// </summary>
        /// <param name="idstatus"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("Authorizing/{idstatus}")]
        public async Task<IActionResult> GetByStatusAndAuthorizing(int idstatus)
        {
            return Ok(await Mediator.Send(new GetByStatusAndAuthorizingDisciplinaryProcessQuery { ProcessStatusId = idstatus }));

        }

        /// <summary>
        /// Metodo que permite actualizar el estado de proceso disciplinario de los estados 1,7,8,9
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessD(int id, PutDisciplinaryProcessCommand command)
        {
            return Ok(await Mediator.Send(command));

        }

        /// <summary>
        /// Método utilizado para actualizar el estado de la solicitud: 6.Procesos en trámites y cambiarlo a estado: (4.proceso aprobado 5.Proceso no Aprobado)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("{idResponse}")]
        public async Task<IActionResult> PutProcessResponse([FromForm] PutResponseDisciplinaryProcessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("SendEmail/{email}")]
        public async Task<IActionResult> SendMailNotification(string email)
        {
            return Ok(await Mediator.Send(new GetSendEmailDisciplinaryProcessQuery { Email = email }));
        }

        /// <summary>
        /// Método que permite traer los procesos disciplinarios por un rango de fechas
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("byrangeday")]
        public async Task<IActionResult> GetDisciplinaryProcessByDate(DateTime startDate, DateTime endDate, int status)
        {
            return Ok(await Mediator.Send(new GetDisciplinaryProcessByDateQuery() { StartDate = startDate, EndDate = endDate, Status = status }));

        }
    }
}
