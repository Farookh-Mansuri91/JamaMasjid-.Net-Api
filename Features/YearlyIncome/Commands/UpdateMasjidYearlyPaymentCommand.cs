using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Commands
{
    public class UpdateMasjidYearlyPaymentCommand:IRequest<MasjidIncomeResponseModel>
    {
        public MasjidIncomeDTO MasjidIncomeDTO { get; set; }
    }

}
