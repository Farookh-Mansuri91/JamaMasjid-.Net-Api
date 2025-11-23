using MediatR;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;

namespace SunniNooriMasjidAPI.Features.VillageMember.Queries
{
    public class GetVillageMohallaQuery : IRequest<IEnumerable<VillageMohallaResponseModel>> { }
}
