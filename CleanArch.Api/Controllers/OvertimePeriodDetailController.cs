using Application.Cqrs.OvertimePeriodDetail.Commands;
using Application.Cqrs.OvertimePeriodDetail.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/overtimePeriodDetail")]
    [Authorize]
    [ApiExplorerSettings(GroupName = "OvertimePeriodDetail")]
    public class OvertimePeriodDetailController : ApiControllerBase
    {

        /// <summary>
        /// Obtiene el detalle de todos lo ciclos de horas extras registrados.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetOvertimesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Método para obtener el detalle de hora extra, filtrando por Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOvertimeDetailById(Guid id)
        {
            var response = await Mediator.Send(new GetOvertimeDetailByIdQuery { Id = id });

            if (!response.Result) return BadRequest(response.Message);
           
            return Ok(response);
        }

        /// <summary>
        /// Obtiene el detalle de un ciclo de hora extra, filtrando por periodo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/GetByPeriodId/{id}")]
        public async Task<IActionResult> GetByPeriodId(int id)
        {
            return Ok(await Mediator.Send(new GetOvertimesByPeriodQuey() { id = id }));
        }

        /// <summary>
        /// Obtiene el detalle de horas extras por usuario de session en un periodo determinado.
        /// </summary>
        /// <param name="periodId"></param>
        /// <returns></returns>
        [HttpGet("/api/GetmyOvertimesUploaded/{periodId}")]
        public async Task<IActionResult> GetmyOvertimesUploaded(int periodId)
        {
            var response = await Mediator.Send(new GetOvertimesByPeriodAndUserIdQuey() { PeriodId = periodId });

            return Ok(response);
        }

        /// <summary>
        /// Obtiene una lista con el detalle de hora extra que no han sido aprobadas.
        /// Se debe pasar por parámetro el id del periodo.
        /// </summary>
        /// <param name="periodId"></param>
        /// <returns></returns>
        [HttpGet("/api/pending-aproval/{periodId}")]
        public async Task<IActionResult> GetOvertimesDetailPendingApproval(int periodId)
        {
            var response = await Mediator.Send(new GetOvertimesDetailPendingApprovalQuery() { PeriodId = periodId });

            //if (!response.Result) return BadRequest(response.Message);
           
            return Ok(response);
        }

        /// <summary>
        /// Agrega un nuevo registro, almacenando el detalle de hora extra.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(PostOvertimeCommand query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Elimina un Detalle del periodo existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetail(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteOvertimeDetailCommand() { Id = id }));
        }


        /// <summary>
        /// Método que se encarga de editar el detalle de hora extra.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutOvertimeCommand query)
        {

            //if (id != query.Id) return BadRequest();

            var response = await Mediator.Send(query);

            //if (!response.Result) return BadRequest(response.Message);
           
            return Ok(response);
        }

        /// <summary>
        /// Método que se encarga de aprobar las horas extras de forma masiva.
        /// Este método recibe un array de datos tipo Guid, correspondientes al Id de cada registro que se
        /// desea editar.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPut("/api/massive-approval")]
        public async Task<IActionResult> ApprovalMassive(PutRangeOvertimeDetailCommand query)
        {                       

            var response = await Mediator.Send(query);

            if (!response.Result) return BadRequest(response.Message);

            return Ok(response);
        }

    }
}
