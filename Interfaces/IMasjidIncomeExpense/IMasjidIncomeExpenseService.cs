using SunniNooriMasjidAPI.Features.Models.MasjidIncomeExpense.Response;

namespace SunniNooriMasjidAPI.Interfaces.IMasjidIncomeExpense
{
    public interface IMasjidIncomeExpenseService
    {
       public Task<IEnumerable<MasjidIncomeExpenseResponseModel>> GetIncomeExpenseDataAsync();
    }
}
