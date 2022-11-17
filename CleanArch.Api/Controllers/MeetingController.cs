using Application.Cqrs.Meetings.Meeting.Commands;
using Application.Cqrs.Meetings.Meeting.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/meeting")]
    [ApiController]
    //[Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class MeetingController : ApiControllerBase
    {
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdMeeting(int id)
        {
            return Ok(await Mediator.Send(new GetByIdMeetingQuery { Id = id }));
        }
        [HttpPut("startmeeting/{id}")]
        public async Task<IActionResult> PutStartMeeting(PutStartMeetingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
