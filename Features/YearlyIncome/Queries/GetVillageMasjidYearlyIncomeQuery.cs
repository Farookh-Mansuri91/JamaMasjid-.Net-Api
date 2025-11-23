using MediatR;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Queries
{
    public class GetVillageMasjidYearlyIncomeQuery:IRequest<List<MasjidYearlyIncomeDTO>>
    {
    }
}
