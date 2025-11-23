using MediatR;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Handlers
{

    public class GetVillageMohallaQueryHandler : IRequestHandler<GetVillageMohallaQuery, IEnumerable<VillageMohallaResponseModel>>
    {
        private readonly IVillageMemberService _villageMemberService;

        public GetVillageMohallaQueryHandler(IVillageMemberService villageMemberService)
        {
            _villageMemberService = villageMemberService;
        }


        public async Task<IEnumerable<VillageMohallaResponseModel>> Handle(GetVillageMohallaQuery request, CancellationToken cancellationToken)
        {
            return await _villageMemberService.GetMohallaDataAsync();
        }
    }
}
