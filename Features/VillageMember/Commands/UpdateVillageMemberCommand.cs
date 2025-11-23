using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Request;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;

namespace SunniNooriMasjidAPI.Features.VillageMember.Commands
{
    public class UpdateVillageMemberCommand : IRequest<UpdateVillageMemberResponseModel>
    {
        public VillageMemberRequestModel VillageMemberRequest { get; set; }
        public int UpdatedBy { get; set; }
    }
}
