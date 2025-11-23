using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Request;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Commands
{
    public class AddVillageMemberCommand : IRequest<int>
    {
        public VillageMemberRequestModel VillageMemberRequest { get; set; }
        public int CreatedBy { get; set; }
    }
}
