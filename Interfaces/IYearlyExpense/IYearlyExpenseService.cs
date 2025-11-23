using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;

namespace SunniNooriMasjidAPI.Interfaces.IYearlyExpense
{
    public interface IYearlyExpenseService
    {
        public Task<ExpenseResponseWrapper> GetYearlyExpenseAsync(int year);
        public Task<AddUpdateExpenseResponseModel> AddYearlyExpenseAsync(AddUpdateExpenseRequestModel requestModel);
        public Task<AddUpdateExpenseResponseModel> UpdateYearlyExpenseAsync(AddUpdateExpenseRequestModel requestModel);
    }
}
