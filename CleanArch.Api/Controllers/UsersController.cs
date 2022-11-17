using Application.Cqrs.ResponsabilitiesCostCenter.Queries;
using Application.Cqrs.User.Commands;
using Application.Cqrs.User.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Users")]
    public class UsersController : ApiControllerBase
    {
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("usersbycostcenter")]
        public async Task<IActionResult> GetUserByCostCenter([FromQuery] GetUserResponsabilityCostCenterQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Agrega un nuevo usuario en la base de datos, validando inicialmente en Mekano.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]      
        public async Task<IActionResult> PostUser([FromBody] PostUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
               
        /// <summary>
        /// Edita un usuario existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, PutUserCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Elimina un usuario existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { Id = id }));
        }

        /// <summary>
        /// Activa el estado de un usuario existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/activate")]
        public async Task<IActionResult> StatusActivateUserById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusActivateUserById() { Id = id }));
        }

        /// <summary>
        /// Inactiva el estado de un usuario existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/deactivate")]
        public async Task<IActionResult> StatusDeactivateUserById(Guid id)
        {
            return Ok(await Mediator.Send(new PutStatusDeactivateUserById() { Id = id }));
        }
             

    }

}
