using Application.Cqrs.Feedbacks.AdditionalQuestion.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Humans.Payroll.Api.Controllers
{
    [Route("api/talkingpoint")]
    [ApiController]
    //[Authorize]
    [ApiExplorerSettings(GroupName = "Feedback")]
    public class TalkingPointController : ApiControllerBase
    {
        [HttpGet("meetingid{meetingid}")]
        public async Task<IActionResult> GetByMeetingIdTalkingPoint(int meetingid)
        {
            return Ok(await Mediator.Send(new GetByMeetingIdTalkingPointQuery { MeetingId = meetingid }));
        }
    }
}
