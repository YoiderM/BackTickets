using Application.Configurations.Categories.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    [Authorize]

    [ApiExplorerSettings(GroupName = "Categories")]
    public class CategoriesController : ApiControllerBase
    {

        /// <summary>
        /// Método permite obtener las categorias
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCategoryQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
