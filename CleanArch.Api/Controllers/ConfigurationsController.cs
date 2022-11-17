using Application.Configurations.Queries.GetByCategoryIdConfigurations;
using ClaroFidelizacion.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
   
    [Route("api/Configuration")]
    [ApiController]
    [Authorize]

    [ApiExplorerSettings(GroupName = "Configuration")]
    public class ConfigurationsController : ApiControllerBase
    {
        /// <summary>
        /// Método permite obtener el listado de configuraciones
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(Guid categoryId)
        {
            return Ok(await Mediator.Send(new GetByCategoryIdConfigurationQuery { CategoryId = categoryId }));
        }
    }
}
