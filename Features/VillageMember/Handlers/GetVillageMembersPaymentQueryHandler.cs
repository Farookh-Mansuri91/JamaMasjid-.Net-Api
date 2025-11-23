using MediatR;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Handlers
{
    public class GetVillageMembersPaymentQueryHandler: IRequestHandler<GetVillageMembersPaymentQuery, List<VillageMemberDTO>>
    {
        private readonly IVillageMemberService _villageMemberService;

        public GetVillageMembersPaymentQueryHandler(IVillageMemberService villageMemberService)
        {
            _villageMemberService = villageMemberService;
        }


        public async Task<List<VillageMemberDTO>> Handle(GetVillageMembersPaymentQuery request, CancellationToken cancellationToken)
        {
            return await _villageMemberService.GetMembersPaymentAsync();
        }
    }
}
