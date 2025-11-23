using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Request;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;
using SunniNooriMasjidAPI.Features.YearlyIncome.Commands;
using SunniNooriMasjidAPI.Features.YearlyIncome.Queries;

namespace SunniNooriMasjidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearlyIncomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public YearlyIncomeController(IMediator mediator)
        {
            _mediator = mediator;

        }

        // new
        [HttpGet("masjidYearlyIncome")]
        public async Task<ActionResult<List<MasjidYearlyIncomeDTO>>> GetVillageMasjidYearlyIncome(CancellationToken cancellationToken)
        {
            // Send the query without the year parameter, as filtering by year will now be done on the frontend.
            var query = new GetVillageMasjidYearlyIncomeQuery();
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost("addMasjidYearlyPayment")]
        public async Task<IActionResult> AddMasjidYearlyPayment([FromBody] MasjidIncomeRequestModel request)
        {

            // Create the command to update the member
            var command = new AddMasjidYearlyIncomeCommand()
            {
                AddMasjidIncome = request

            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Masjid payment added successfully." });
        }


        [HttpPut("updateMasjidYearlyPayment")]
        public async Task<IActionResult> updateMasjidYearlyPaymentDetails([FromBody] MasjidIncomeDTO request)
        {
            // Create the command to update the payment
            var command = new UpdateMasjidYearlyPaymentCommand
            {
                MasjidIncomeDTO = request

            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Payment updated successfully." });
        }

    }
}
