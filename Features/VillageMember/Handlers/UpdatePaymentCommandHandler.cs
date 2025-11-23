using MediatR;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.VillageMember.Handlers
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, bool>
    {
        private readonly IVillageMemberService _villageMemberService;

        public UpdatePaymentCommandHandler(IVillageMemberService villageMemberService)
        {
            _villageMemberService = villageMemberService;
        }

        public async Task<bool> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            // Call the service layer to update the payment
            return await _villageMemberService.UpdatePaymentAsync(request.MemberId,request.PaymentId, request.Amount, request.PaymentDate, request.Year);
        }
    }
}
