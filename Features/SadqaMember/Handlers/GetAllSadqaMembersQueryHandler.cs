using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Queries;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Handlers
{
    public class GetAllSadqaMembersQueryHandler: IRequestHandler<GetAllSadqaMembersQuery,IEnumerable<SadqaMemberResponseModel>>
    {
        private readonly ISadqaMemberService _sadqaMemberService;

        public GetAllSadqaMembersQueryHandler(ISadqaMemberService sadqaMemberService)
        {
            _sadqaMemberService = sadqaMemberService;
        }


        public async Task<IEnumerable<SadqaMemberResponseModel>> Handle(GetAllSadqaMembersQuery request, CancellationToken cancellationToken)
        {
            return await _sadqaMemberService.GetSadqaMemberDataAsync();
        }
    }
}
