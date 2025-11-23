using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Queries;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Handlers
{

    public class GetAllVillageMemberQueryHandler : IRequestHandler<GetAllVillageMemberQuery, IEnumerable<VillageMemberResponseModel>>
    {
        private readonly IVillageMemberService _villageMemberService;

        public GetAllVillageMemberQueryHandler(IVillageMemberService villageMemberService)
        {
            _villageMemberService = villageMemberService;
        }


        public async Task<IEnumerable<VillageMemberResponseModel>> Handle(GetAllVillageMemberQuery request, CancellationToken cancellationToken)
        {
            return await _villageMemberService.GetVillageMemberDataAsync();
        }
    }
}
