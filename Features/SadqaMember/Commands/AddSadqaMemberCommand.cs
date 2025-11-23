using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Commands
{
    public class AddSadqaMemberCommand : IRequest<int>
    {
        public SadqaMemberRequestModel SadqaMemberRequest { get; set; }
     
    }
}
