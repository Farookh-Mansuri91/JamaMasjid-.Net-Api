using MediatR;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;
using SunniNooriMasjidAPI.Features.YearlyExpenses.Queries;
using SunniNooriMasjidAPI.Features.YearlyIncome.Queries;
using SunniNooriMasjidAPI.Interfaces.IYearlyExpense;
using SunniNooriMasjidAPI.Interfaces.IYearlyIncome;

namespace SunniNooriMasjidAPI.Features.YearlyExpenses.Handlers
{
    public class GetAllYearlyExpenseQueryHandler : IRequestHandler<GetAllYearlyExpenseQuery, ExpenseResponseWrapper>
    {
        private readonly IYearlyExpenseService _yearlyExpenseService;

        public GetAllYearlyExpenseQueryHandler(IYearlyExpenseService yearlyExpenseService)
        {
            _yearlyExpenseService = yearlyExpenseService;
        }


        public async Task<ExpenseResponseWrapper> Handle(GetAllYearlyExpenseQuery request, CancellationToken cancellationToken)
        {
            return await _yearlyExpenseService.GetYearlyExpenseAsync(request.Year);
        }
    }
}
