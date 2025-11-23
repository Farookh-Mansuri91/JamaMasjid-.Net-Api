using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.YearlyIncome.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;
using SunniNooriMasjidAPI.Interfaces.IYearlyIncome;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Handlers
{
 
    public class AddMasjidYearlyIncomeCommandHandler : IRequestHandler<AddMasjidYearlyIncomeCommand, MasjidIncomeResponseModel>
    {
        private readonly IYearlyIncomeService _service;
        public AddMasjidYearlyIncomeCommandHandler(IYearlyIncomeService service)
        {
            _service = service;

        }

        public async Task<MasjidIncomeResponseModel> Handle(AddMasjidYearlyIncomeCommand request, CancellationToken cancellationToken)
        {

            return await _service.AddMasjidIncomePaymentAsync(request.AddMasjidIncome);
        }
    }
}
