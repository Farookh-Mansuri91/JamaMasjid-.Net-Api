using MediatR;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;

namespace SunniNooriMasjidAPI.Features.YearlyExpenses.Queries
{
    public class GetAllYearlyExpenseQuery : IRequest<ExpenseResponseWrapper> { public int Year { get; set; } }
}
