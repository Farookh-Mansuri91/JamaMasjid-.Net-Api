using MediatR;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Queries
{
    public class GetAllSadqaMembersQuery : IRequest<IEnumerable<SadqaMemberResponseModel>> { }
}
