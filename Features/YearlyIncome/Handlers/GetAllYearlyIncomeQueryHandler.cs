using MediatR;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;
using SunniNooriMasjidAPI.Features.YearlyIncome.Queries;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;
using SunniNooriMasjidAPI.Interfaces.IYearlyIncome;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Handlers
{
 
    public class GetAllYearlyIncomeQueryHandler : IRequestHandler<GetAllYearlyIncomeQuery, IEnumerable<YearlyIncomeResponseModel>>
    {
        private readonly IYearlyIncomeService _yearlyIncomeService;

        public GetAllYearlyIncomeQueryHandler(IYearlyIncomeService yearlyIncomeService)
        {
            _yearlyIncomeService = yearlyIncomeService;
        }


        public async Task<IEnumerable<YearlyIncomeResponseModel>> Handle(GetAllYearlyIncomeQuery request, CancellationToken cancellationToken)
        {
            return await _yearlyIncomeService.GetYearlyIncomeAsync(request.Year);
        }
    }
}
