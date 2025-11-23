using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Handlers
{
 
    public class UpdateVillageMemberCommandHandler : IRequestHandler<UpdateVillageMemberCommand, UpdateVillageMemberResponseModel>
    {
        private readonly IVillageMemberService _villageMemberService;

        public UpdateVillageMemberCommandHandler(IVillageMemberService villageMemberService)
        {
            _villageMemberService = villageMemberService;
        }
        public async Task<UpdateVillageMemberResponseModel> Handle(UpdateVillageMemberCommand request, CancellationToken cancellationToken)
        {
            return await _villageMemberService.UpdateVillageMemberAsync(request.VillageMemberRequest, request.UpdatedBy);
        }
    }
}
