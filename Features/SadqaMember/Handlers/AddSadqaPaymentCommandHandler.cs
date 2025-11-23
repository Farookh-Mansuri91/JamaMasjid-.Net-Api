using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Handlers
{
    public class AddSadqaPaymentCommandHandler: IRequestHandler<AddSadqaPaymentCommand,UpdateSadqaMemberResponseModel>
    {
        private readonly ISadqaMemberService _service;
       public AddSadqaPaymentCommandHandler(ISadqaMemberService service) { 
            _service = service;
        
        }

        public async Task<UpdateSadqaMemberResponseModel> Handle(AddSadqaPaymentCommand request, CancellationToken cancellationToken) {

            return await _service.AddSadqaPaymentAsync(request.AddSadqaPaymentRequest);
        }
    }
}
