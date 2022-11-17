using Application.Cqrs.Mekano.Queries;
using Application.Cqrs.ResponsabilitiesCostCenter.Commands;
using Application.Cqrs.ResponsabilitiesCostCenter.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/costcenter")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "CostCenter")]
    public class CostCenterController : ApiControllerBase
    {
        /// <summary>
        /// Método que retorna todos los Centros de costos existentes en el sistema.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCostCenter([FromQuery] GetCostCenterQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo que retorna el Centro de Costos y el Status  por el Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCostCenterId(int id)
        {
            return Ok(await Mediator.Send(new GetCostCenterByIdQuery() { Id = id }));
        }

        /// <summary>
        /// Crea Responsable para el Centro de costos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostResponsabilityCostCenterCommand query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Retorna el responsable del Centro de Costos para las horas extras.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("responsabilities-costcenter")]
        public async Task<IActionResult> Get([FromQuery] GetResponsabilityCostCenterByDocQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("Userresponsability-costcenter")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUserResponsabilityCostCenterQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Método que retorna los responsables del centro de costos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("responsible-costcenter")]
        public async Task<IActionResult> GetAll([FromQuery] GetResponsibleCostCenterQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [HttpGet("responsible-costcenter-by-user")]
        public async Task<IActionResult> GetAllByUser([FromQuery] GetResponsibleCostCenterByUserQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Retorna los datos del empleado validado en Mekano y que esté activo
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpGet("/api/MekanoUser/{document}")]
        public async  Task<IActionResult> GetMekanoUserByDocument(string document)
        {
            return Ok(await Mediator.Send(new GetMekanoUserByIdQuery() { Document = document}));
        }

        /// <summary>
        /// Método que retorna los los centros de costos asociados al usuario ingresado como parámetro
        /// </summary>
        /// <param name="CostCenterUserId"></param>
        /// <returns></returns>
        [HttpGet("/api/MekanoUserValidate/{CostCenterUserId}")]
        public async Task<IActionResult> ValidateResponsibleCostCenter(int CostCenterUserId)
        {
            return Ok(await Mediator.Send(new GetValidateResponsibleCostCenterQuery() { CostCenterUserId = CostCenterUserId }));
        }

    }
}
