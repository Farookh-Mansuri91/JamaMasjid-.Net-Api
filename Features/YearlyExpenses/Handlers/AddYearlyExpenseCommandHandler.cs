using MediatR;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;
using SunniNooriMasjidAPI.Features.YearlyExpenses.Commands;
using SunniNooriMasjidAPI.Interfaces.IYearlyExpense;

namespace SunniNooriMasjidAPI.Features.YearlyExpenses.Handlers
{
    public class AddYearlyExpenseCommandHandler:IRequestHandler<AddYearlyExpenseCommand,AddUpdateExpenseResponseModel>
    {
        IYearlyExpenseService _service;
        public AddYearlyExpenseCommandHandler(IYearlyExpenseService  service) { 
        _service = service;
        }
        public async Task<AddUpdateExpenseResponseModel> Handle(AddYearlyExpenseCommand request, CancellationToken cancellationToken) {
            return await _service.AddYearlyExpenseAsync(request.AddExpense);
        }
    }
}
