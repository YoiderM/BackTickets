using Application.Cqrs.OvertimePeriods.Commands;
using Application.Cqrs.OvertimePeriods.Queries;
using Application.Cqrs.OvertimePeriods.Queries.GetOvertimePeriodById;
using Application.Cqrs.OvertimePeriods.Queries.GetPeriods;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "OvertimePeriod")]
    public class OvertimePeriodController : ApiControllerBase
    {
        /// <summary>
        /// Retorna todos los ciclos de horas extras.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetOvertimePeriodQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        /// <summary>
        /// Crea un nuevo ciclo para las horas extras.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOvertimePeriodcommand query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Obtiene un ciclo filtrando por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPeriodId(int id)
        {
            return Ok(await Mediator.Send(new GetOvertimePeriodByIdQuery() { Id = id }));
        }
    
        /// <summary>
        /// Metodo que retorna los periodos que han sido pagados
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/Api/OvertimePeriodIsPaid")]
        public async  Task<IActionResult> GetPeriodsIsPaid([FromQuery] GetOvertimePeriodIspaidQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo que retorna los periodos que aún no han sido pagados
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/Api/OvertimePeriodIsNotPaid")]
        public async Task<IActionResult> GetPeriodsIsNotPaid([FromQuery] GetOvertimePeriodIsNotPaidQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Actualiza un ciclo existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]    
        public async Task<IActionResult> Put(int id, UpdateOvertimePeriodCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Proceso para subir archivo de excel con los registros de horas extras de los empleados.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="OvertimePeriodId"></param>
        /// <returns></returns>
        [HttpPost("/api/UploadOvertime")]
         
        public async Task<IActionResult> UploadOvertime(IFormFile file ,int OvertimePeriodId)
        {
            var result = await Mediator.Send(new UploadOvertimesPeriodCommand() { File = file , OvertimePeriodId = OvertimePeriodId });
                 
            return Ok(result);
        }


        /// <summary>
        /// Metodo para eliminar los periodos que no han sido aprobados y que esten abiertos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteOvertimePeriodCommand() { Id = id }));

        }
    }
}
