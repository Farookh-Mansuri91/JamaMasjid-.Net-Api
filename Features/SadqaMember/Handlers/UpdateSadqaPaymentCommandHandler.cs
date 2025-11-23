using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Handlers
{
    public class UpdateSadqaPaymentCommandHandler : IRequestHandler<UpdateSadqaPaymentCommand, UpdateSadqaMemberResponseModel>
    {
        private readonly ISadqaMemberService _sadqaMemberService;

        public UpdateSadqaPaymentCommandHandler(ISadqaMemberService sadqaMemberService)
        {
            _sadqaMemberService = sadqaMemberService;
        }

        public async Task<UpdateSadqaMemberResponseModel> Handle(UpdateSadqaPaymentCommand request, CancellationToken cancellationToken)
        {
            // Call the service layer to update the payment
            return await _sadqaMemberService.UpdateSadqaPaymentAsync(request.UpdateSadqaPaymentRequest);
        }
    }
}
