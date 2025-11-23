using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.YearlyIncome.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;
using SunniNooriMasjidAPI.Interfaces.IYearlyIncome;
using SunniNooriMasjidAPI.Services.YearlyIncomeService;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Handlers
{
    public class UpdateMasjidYearlyIncomePaymentHandler : IRequestHandler<UpdateMasjidYearlyPaymentCommand, MasjidIncomeResponseModel>
    {
        public readonly IYearlyIncomeService _yearlyIncomeService;
       public UpdateMasjidYearlyIncomePaymentHandler(IYearlyIncomeService service)
        {

            _yearlyIncomeService = service;
        }

        public async Task<MasjidIncomeResponseModel> Handle(UpdateMasjidYearlyPaymentCommand request, CancellationToken cancellationToken)
        {
            // Call the service layer to update the payment
            return await _yearlyIncomeService.UpdateMasjidIncomePaymentAsync(request.MasjidIncomeDTO);
        }
    }
}
