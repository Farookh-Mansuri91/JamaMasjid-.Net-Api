using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Request;
using SunniNooriMasjidAPI.Features.YearlyExpenses.Commands;
using SunniNooriMasjidAPI.Features.YearlyExpenses.Queries;
using SunniNooriMasjidAPI.Features.YearlyIncome.Commands;
using SunniNooriMasjidAPI.Features.YearlyIncome.Queries;

namespace SunniNooriMasjidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearlyExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public YearlyExpenseController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllYearlyExpenses([FromQuery] int year)
        {
            if (year <= 0)
            {
                return BadRequest("Invalid year provided.");
            }

            var members = await _mediator.Send(new GetAllYearlyExpenseQuery { Year = year });
            return Ok(members);
        }
        [HttpPost("addExpense")]
        public async Task<IActionResult> AddMasjidExpenses([FromBody] AddUpdateExpenseRequestModel request)
        {

            // Create the command to Add the expense
            var command = new AddYearlyExpenseCommand()
            {
                AddExpense = request

            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Expense  added successfully." });
        }


        [HttpPut("updateExpense")]
        public async Task<IActionResult> updateMasjidExpense([FromBody] AddUpdateExpenseRequestModel request)
        {
            // Create the command to update the payment
            var command = new UpdateYearlyExpenseCommand
            {
                UpdateExpense = request

            };

            // Send the command via mediator
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "Expense updated successfully." });
        }
    }
}
