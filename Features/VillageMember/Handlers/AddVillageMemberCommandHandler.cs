using MediatR;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Handlers
{
    public class AddVillageMemberCommandHandler : IRequestHandler<AddVillageMemberCommand, int>
    {
        private readonly IVillageMemberService _villageMemberService;

        public AddVillageMemberCommandHandler(IVillageMemberService villageMemberService)
        {
            _villageMemberService = villageMemberService;
        }

        public async Task<int> Handle(AddVillageMemberCommand request, CancellationToken cancellationToken)
        {
            return await _villageMemberService.AddVillageMemberAsync(request.VillageMemberRequest, request.CreatedBy);
        }
    }
}
