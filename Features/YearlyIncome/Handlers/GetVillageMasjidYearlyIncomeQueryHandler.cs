using MediatR;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;
using SunniNooriMasjidAPI.Features.YearlyIncome.Queries;
using SunniNooriMasjidAPI.Interfaces.IYearlyIncome;
using System.Collections.Generic;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Handlers
{
    public class GetVillageMasjidYearlyIncomeQueryHandler : IRequestHandler<GetVillageMasjidYearlyIncomeQuery, List<MasjidYearlyIncomeDTO>>
    {
        IYearlyIncomeService _service;
        public GetVillageMasjidYearlyIncomeQueryHandler(IYearlyIncomeService service)
        {
            _service = service;

        }
        public async Task<List<MasjidYearlyIncomeDTO>> Handle(GetVillageMasjidYearlyIncomeQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetVillageMasjidYearlyIncomeAsync();

        }
    }
}
