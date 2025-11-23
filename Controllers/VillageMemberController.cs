using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Common;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Request;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.SadqaMember.Queries;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;

namespace SunniNooriMasjidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillageMemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VillageMemberController(IMediator mediator)
        {
            _mediator = mediator;

        }
        

        [HttpGet("mohalla")]
        public async Task<IActionResult> GetAllMohallas()
        {
            var members = await _mediator.Send(new GetVillageMohallaQuery());
            return Ok(members);
        }

        //// todo
        //[HttpGet("getMembers")]
        //public async Task<IActionResult> GetAllMembers()
        //{
        //    var members = await _mediator.Send(new GetVillageMohallaQuery());
        //    return Ok(members);
        //}

        [HttpGet("payments")]
        public async Task<ActionResult<List<VillageMemberDTO>>> GetPayments(CancellationToken cancellationToken)
        {
            // Send the query without the year parameter, as filtering by year will now be done on the frontend.
            var query = new GetVillageMembersPaymentQuery();
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost("payments")]
        public async Task<IActionResult> AddPayment([FromBody] AddPaymentCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentId = await _mediator.Send(command);
            return Ok(new { PaymentId = paymentId, Message = "Payment added successfully." });
        }


        [HttpPut("payments/{memberId}/{year}")]
        public async Task<IActionResult> UpdatePayment(int memberId, int year, [FromBody] UpdatePaymentCommand command)
        {
            // Ensure the command's memberId and year match the route parameters
            if (memberId != command.MemberId || year != command.Year)
            {
                return BadRequest("Member ID or Year mismatch.");
            }

            // Call the MediatR handler
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok("Payment updated successfully.");
            }

            return NotFound("Payment not found for the given member and year.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVillageMembers()
        {
            var members = await _mediator.Send(new GetAllVillageMemberQuery());
            return Ok(members);
        }

        // old
        //[Authorize(Roles = "Member")]
        [HttpPost("addVillageMember")]
        public async Task<IActionResult> AddVillageMember([FromBody] VillageMemberRequestModel request)
        {
            // Extracting user information from the token
            //var addedBy = AuthHelpers.GetUserIdFromClaims(User);

            //if (addedBy == null)
            //    return Unauthorized("User not authorized to perform this action.");

            var command = new AddVillageMemberCommand
            {
                VillageMemberRequest = request,
            };

            var memberId = await _mediator.Send(command);
            return Ok(new { MemberId = memberId, Message = "Village Member added successfully." });
        }


        //[Authorize(Roles = "Member")]
        [HttpPut("updateVillageMember")]
        public async Task<IActionResult> UpdateVillageMember([FromBody] VillageMemberRequestModel request)
        {
            // Extracting user information from the token
            //var updatedBy = AuthHelpers.GetUserIdFromClaims(User);

            //if (updatedBy == null)
            //    return Unauthorized("User not authorized to perform this action.");

            // Create the command to update the member
            var command = new UpdateVillageMemberCommand
            {
                VillageMemberRequest = request,
               
            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Village Member updated successfully." });
        }



    }
}
