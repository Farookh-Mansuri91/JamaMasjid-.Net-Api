using MediatR;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;

namespace SunniNooriMasjidAPI.Features.VillageMember.Queries
{
    public class GetVillageMembersPaymentQuery: IRequest<List<VillageMemberDTO>>
    {
  
    }
}
