using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;
using SunniNooriMasjidAPI.Features.YearlyIncome.Commands;

namespace SunniNooriMasjidAPI.Interfaces.IYearlyIncome
{
    public interface IYearlyIncomeService
    {
        //public Task<IEnumerable<YearlyIncomeResponseModel>> GetYearlyIncomeAsync(int year);
        Task<List<MasjidYearlyIncomeDTO>> GetVillageMasjidYearlyIncomeAsync();
        Task<MasjidIncomeResponseModel> AddMasjidIncomePaymentAsync(MasjidIncomeRequestModel request);
        Task<MasjidIncomeResponseModel> UpdateMasjidIncomePaymentAsync(MasjidIncomeDTO request);
    }
}
