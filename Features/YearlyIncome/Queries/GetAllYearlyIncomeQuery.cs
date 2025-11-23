using MediatR;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Queries
{
    public class GetAllYearlyIncomeQuery : IRequest<IEnumerable<YearlyIncomeResponseModel>> { public int Year { get; set; } }
}
