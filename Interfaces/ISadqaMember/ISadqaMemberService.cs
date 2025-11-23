using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;

namespace SunniNooriMasjidAPI.Interfaces.ISadqaMember
{
    public interface ISadqaMemberService
    {
        public Task<IEnumerable<SadqaMemberResponseModel>> GetSadqaMemberDataAsync();
        Task<int> AddSadqaMemberAsync(SadqaMemberRequestModel request);
        Task<UpdateSadqaMemberResponseModel> UpdateSadqaMemberAsync(SadqaMemberRequestModel request);
        Task<IEnumerable<SadqaMemberPaymentResponseModel>> GetAllSadqaPymentMembersAsync();
        Task<UpdateSadqaMemberResponseModel> UpdateSadqaPaymentAsync(UpdateSadqaPaymentRequestModel request);
        Task<UpdateSadqaMemberResponseModel> AddSadqaPaymentAsync(AddSadqaPaymentRequestModel request);
    }
}
