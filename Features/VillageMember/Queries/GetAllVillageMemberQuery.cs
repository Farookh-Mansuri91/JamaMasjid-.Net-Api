using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;

namespace SunniNooriMasjidAPI.Features.VillageMember.Queries
{
    public class GetAllVillageMemberQuery : IRequest<IEnumerable<VillageMemberResponseModel>> { }
}
