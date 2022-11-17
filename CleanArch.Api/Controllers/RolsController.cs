using Application.Cqrs.Rol.Commands;
using Application.Cqrs.Rol.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/rols")]
    [ApiController]
    //[Authorize]
    [ApiExplorerSettings(GroupName = "Rols")]
    public class RolsController : ApiControllerBase
    {
        /// <summary>
        /// Obtiene todos los roles.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRol([FromQuery] GetRolQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Agrega un nuevo rol.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] PostRolCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Edita un rol existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(Guid id, PutRolCommand command)
        {
            if (id != command.Id) return BadRequest();
            

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Elimina un rol existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteRolCommand() { Id = id }));
        }

        /// <summary>
        /// Activa el estado de un rol existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/activate")]
        public async Task<IActionResult> StatusActivateRolById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusActivateRolById() { Id = id }));
        }

        /// <summary>
        /// Inactiva el estado de un rol existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/deactivate")]
        public async Task<IActionResult> StatusDeactivateRolById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusDeactivateRolById() { Id = id }));
        }
    }
}
