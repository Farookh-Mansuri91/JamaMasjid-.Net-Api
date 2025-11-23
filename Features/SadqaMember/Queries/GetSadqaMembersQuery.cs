using MediatR;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Queries
{
    public class GetSadqaMembersQuery : IRequest<IEnumerable<SadqaMemberPaymentResponseModel>>
    {
    }
}
