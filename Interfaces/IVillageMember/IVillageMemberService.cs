using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Request;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;

namespace SunniNooriMasjidAPI.Interfaces.IVillageMember
{
    public interface IVillageMemberService
    {
        public Task<IEnumerable<VillageMemberResponseModel>> GetVillageMemberDataAsync();
        Task<int> AddVillageMemberAsync(VillageMemberRequestModel request, int createdBy);
        Task<UpdateVillageMemberResponseModel> UpdateVillageMemberAsync(VillageMemberRequestModel request, int updatedBy);

        Task<List<VillageMemberDTO>> GetMembersPaymentAsync();
        Task<bool> UpdatePaymentAsync(int memberId,int paymentId , decimal amount, string paymentDate, int year);
        Task<int> AddPaymentAsync(AddPaymentCommand command);
        public Task<IEnumerable<VillageMohallaResponseModel>> GetMohallaDataAsync();
    }
}
