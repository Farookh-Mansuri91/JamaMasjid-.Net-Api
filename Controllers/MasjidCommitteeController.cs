using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Features.MasjidCommittee.Queries;
using SunniNooriMasjidAPI.Features.MasjidGullak.Commands;
using SunniNooriMasjidAPI.Features.MasjidGullak.Queries;

namespace SunniNooriMasjidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasjidCommitteeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MasjidCommitteeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommitteeMember()
        {
            var result = await _mediator.Send(new GetCommitteeMemberQuery());
            return Ok(result);
        }
    }

   
}
