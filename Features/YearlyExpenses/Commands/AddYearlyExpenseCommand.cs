using MediatR;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;

namespace SunniNooriMasjidAPI.Features.YearlyExpenses.Commands
{
    public class AddYearlyExpenseCommand : IRequest<AddUpdateExpenseResponseModel>
    {
       public AddUpdateExpenseRequestModel AddExpense { get; set; }
    }
}
