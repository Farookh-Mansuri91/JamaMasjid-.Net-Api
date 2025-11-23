using MediatR;
using SunniNooriMasjidAPI.Features.MasjidGullak.Queries;
using SunniNooriMasjidAPI.Features.MasjidIncomeExpense.Queries;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;
using SunniNooriMasjidAPI.Features.Models.MasjidIncomeExpense.Response;
using SunniNooriMasjidAPI.Interfaces.IMasjidGullak;
using SunniNooriMasjidAPI.Interfaces.IMasjidIncomeExpense;

namespace SunniNooriMasjidAPI.Features.MasjidIncomeExpense.Handlers
{
    public class GetYearlyIncomeExpenseQueryHandler : IRequestHandler<GetYearlyIncomeExpenseQuery, IEnumerable<MasjidIncomeExpenseResponseModel>>
    {
        private readonly IMasjidIncomeExpenseService _incomeExpenseService;

        public GetYearlyIncomeExpenseQueryHandler(IMasjidIncomeExpenseService incomeExpenseService)
        {
            _incomeExpenseService = incomeExpenseService;
        }

        public async Task<IEnumerable<MasjidIncomeExpenseResponseModel>> Handle(GetYearlyIncomeExpenseQuery request, CancellationToken cancellationToken)
        {
            return await _incomeExpenseService.GetIncomeExpenseDataAsync();
        }
    }
}
