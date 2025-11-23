using MediatR;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;

namespace SunniNooriMasjidAPI.Features.YearlyExpenses.Commands
{
    public class UpdateYearlyExpenseCommand : IRequest<AddUpdateExpenseResponseModel>
    {
       public AddUpdateExpenseRequestModel UpdateExpense { get; set; }
    }
}
