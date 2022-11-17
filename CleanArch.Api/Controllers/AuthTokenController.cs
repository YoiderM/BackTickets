using Application.Auth.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/auth-token")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Auth-Token")]
    public class AuthTokenController : ApiControllerBase
    {

        private readonly ILogger<AuthTokenController> _logger;

        public AuthTokenController(ILogger<AuthTokenController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método que se encarga de generar el token de acceso.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] PostLoginCommand command)
        {

            return Ok(await Mediator.Send(command));
        }
    }
}
