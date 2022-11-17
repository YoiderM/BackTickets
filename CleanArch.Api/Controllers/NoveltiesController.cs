using Application.Cqrs.Novelties.Commands;
using Application.Cqrs.Novelties.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/Novelties")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Novelties")]
    public class NoveltiesController : ApiControllerBase
    {
        /// <summary>
        /// Metodo que retorna todas las personas que tengan el o los estados que se manda en el query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersNoveltiesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo que retorna todas configuraciones de novedades que hay
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getAllConfigurationNovelties")]
        public async Task<IActionResult> GetAllConfigurationNovelties([FromQuery] GetAllConfigurationNoveltiesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo que retorna todas novedades anticipadas que hay
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getAnticipatedNovelties")]
        public async Task<IActionResult> getAnticipatedNovelties([FromQuery] getAnticipatedNoveltiesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo que retorna todos los registros de novedades filtrando por las iniciales sin importar el estado
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getNoveltiesQuery")]
        public async Task<IActionResult> getNovelties([FromQuery] getNoveltiesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo para modificar el estado del usuario
        /// </summary>
        /// <param name="query"></param>>
        /// <returns></returns>
        [HttpPut("PutStatusNoveltiePerson")]
        public async Task<IActionResult> PutStatusNoveltiePerson([FromForm] PutStatusNoveltyPersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Metodo queque retorna todos lo usuarios activos de mekano
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetUsersMekano")]
        public async Task<IActionResult> GetUsersMekano([FromQuery] GetMekanoUsersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Metodo para crear una novedad anticipada
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("PostAnticipatedNovelty")]
        public async Task<IActionResult> PostAnticipatedNovelty([FromForm] PostAnticipatedNoveltyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Metodo que cambia el estado de aprovacion de la novedad 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("PutAnticipatedNovelty")]
        public async Task<IActionResult> PutStatusAnticipatedNovelty([FromForm] PutAnticipatedNoveltyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
