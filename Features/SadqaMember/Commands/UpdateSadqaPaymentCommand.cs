using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Commands
{   
    public class UpdateSadqaPaymentCommand : IRequest<UpdateSadqaMemberResponseModel>
    {
        public UpdateSadqaPaymentRequestModel UpdateSadqaPaymentRequest { get; set; }
    
    }
}
