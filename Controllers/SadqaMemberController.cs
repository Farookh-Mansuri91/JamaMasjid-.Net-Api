using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Common;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.SadqaMember.Queries;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;

namespace SunniNooriMasjidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SadqaMemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SadqaMemberController(IMediator mediator)
        {
            _mediator = mediator;

        }

        // new
        [HttpGet("sadqaMemberPayments")]
        public async Task<ActionResult<List<SadqaMemberPaymentResponseModel>>> GetSadqaMemberPayments(CancellationToken cancellationToken)
        {
            var query = new GetSadqaMembersQuery();
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost("addSadqaPayment")]
        public async Task<IActionResult> AddSadqaPayments([FromBody] AddSadqaPaymentRequestModel request)
        {

            // Create the command to update the member
            var command = new AddSadqaPaymentCommand
            {
                AddSadqaPaymentRequest = request

            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Sadqa payment added successfully." });
        }

        [HttpPut("updateSadqaPayments")]
        public async Task<IActionResult> UpdateSadqaPayments([FromBody] UpdateSadqaPaymentRequestModel request)
        {

            // Create the command to update the member
            var command = new UpdateSadqaPaymentCommand
            {
               UpdateSadqaPaymentRequest = request
             
            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Sadqa Member updated successfully." });
        }

        // Member Form
        [HttpGet("getSadqaMember")]
        public async Task<IActionResult> GetAllSadqaMembers()
        {
            var members = await _mediator.Send(new GetAllSadqaMembersQuery());
            return Ok(members);
        }

        //
        //[Authorize(Roles ="Other")]
        [HttpPost("addSadqaMember")]
        public async Task<IActionResult> AddSadqaMember([FromBody] SadqaMemberRequestModel request)
        {
            // Extracting user information from the token
            //var addedBy = AuthHelpers.GetUserIdFromClaims(User);

            //if (addedBy == null)
            //    return Unauthorized("User not authorized to perform this action.");

            var command = new AddSadqaMemberCommand
            {
                SadqaMemberRequest = request,
            };

            var memberId = await _mediator.Send(command);
            return Ok(new { MemberId = memberId, Message = "Sadqa Member added successfully." });
        }

   
        //[Authorize(Roles = "Other")]
        [HttpPut("updateSadqaMember")]
        public async Task<IActionResult> UpdateSadqaMember([FromBody] SadqaMemberRequestModel request)
        {
            // Extracting user information from the token
            //var updatedBy = AuthHelpers.GetUserIdFromClaims(User);

            //if (updatedBy == null)
            //    return Unauthorized("User not authorized to perform this action.");

            // Create the command to update the member
            var command = new UpdateSadqaMemberCommand
            {
                SadqaMemberRequest = request,
            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Sadqa Member updated successfully." });
        }
    }
}
