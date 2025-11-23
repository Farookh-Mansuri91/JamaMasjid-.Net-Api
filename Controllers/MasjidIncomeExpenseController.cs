using MediatR;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Features.MasjidIncomeExpense.Queries;
using SunniNooriMasjidAPI.Features.YearlyExpenses.Queries;
using System.Reflection.Metadata;

namespace SunniNooriMasjidAPI.Controllers
{
    public class MasjidIncomeExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MasjidIncomeExpenseController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("GetIncomeExpenseData")]
        public async Task<IActionResult> GetIncomeExpenseData()
        {
            var result = await _mediator.Send(new GetYearlyIncomeExpenseQuery());
            return Ok(result);
        }
    }
}
