using MediatR;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;
using SunniNooriMasjidAPI.Features.Models.MasjidIncomeExpense.Response;

namespace SunniNooriMasjidAPI.Features.MasjidIncomeExpense.Queries
{
    public class GetYearlyIncomeExpenseQuery:IRequest<IEnumerable<MasjidIncomeExpenseResponseModel>>{}
}
