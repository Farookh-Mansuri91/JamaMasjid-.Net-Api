using MediatR;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.SadqaMember.Queries;
using SunniNooriMasjidAPI.Features.VillageMember.Queries;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Handlers
{
    public class GetSadqaMembersQueryHandler : IRequestHandler<GetSadqaMembersQuery, IEnumerable<SadqaMemberPaymentResponseModel>>
    {
        private readonly ISadqaMemberService _service;

        public GetSadqaMembersQueryHandler(ISadqaMemberService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<SadqaMemberPaymentResponseModel>> Handle(GetSadqaMembersQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllSadqaPymentMembersAsync();
        }

    }
}