using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Commands
{
    public class UpdateSadqaMemberCommand : IRequest<UpdateSadqaMemberResponseModel>
    {
        public SadqaMemberRequestModel SadqaMemberRequest { get; set; }
       
    }
}
