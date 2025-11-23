using MediatR;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Handlers
{
    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, int>
    {
        private readonly IVillageMemberService _villageMemberService;

        public AddPaymentCommandHandler(IVillageMemberService villageMemberService)
        {
            _villageMemberService = villageMemberService;
        }

        public async Task<int> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentId = await _villageMemberService.AddPaymentAsync(request);
            return paymentId;
        }
    }
}
