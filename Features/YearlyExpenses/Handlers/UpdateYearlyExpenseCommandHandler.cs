using MediatR;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;
using SunniNooriMasjidAPI.Features.YearlyExpenses.Commands;
using SunniNooriMasjidAPI.Interfaces.IYearlyExpense;

namespace SunniNooriMasjidAPI.Features.YearlyExpenses.Handlers
{
    public class UpdateYearlyExpenseCommandHandler:IRequestHandler<UpdateYearlyExpenseCommand,AddUpdateExpenseResponseModel>
    {
        IYearlyExpenseService _yearlyExpenseService;
        public UpdateYearlyExpenseCommandHandler(IYearlyExpenseService yearlyExpenseService) { 
            _yearlyExpenseService = yearlyExpenseService;
        
        }
        public async Task<AddUpdateExpenseResponseModel> Handle(UpdateYearlyExpenseCommand request, CancellationToken cancellationToken) {
            return await _yearlyExpenseService.UpdateYearlyExpenseAsync(request.UpdateExpense);
        }
    }
}
