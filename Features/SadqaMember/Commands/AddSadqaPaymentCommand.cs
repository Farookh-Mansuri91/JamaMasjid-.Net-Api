using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Commands
{
    public class AddSadqaPaymentCommand:IRequest<UpdateSadqaMemberResponseModel>
    {
       public AddSadqaPaymentRequestModel AddSadqaPaymentRequest { get; set; }
    }
}
