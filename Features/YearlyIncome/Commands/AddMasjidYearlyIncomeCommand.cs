using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;

namespace SunniNooriMasjidAPI.Features.YearlyIncome.Commands
{
    public class AddMasjidYearlyIncomeCommand:IRequest<MasjidIncomeResponseModel>
    {
        public MasjidIncomeRequestModel AddMasjidIncome { get; set; }
    }
  
}
