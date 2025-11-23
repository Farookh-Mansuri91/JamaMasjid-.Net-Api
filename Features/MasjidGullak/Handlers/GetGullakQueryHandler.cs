using MediatR;
using SunniNooriMasjidAPI.Features.MasjidGullak.Queries;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;
using SunniNooriMasjidAPI.Interfaces.IMasjidGullak;

namespace SunniNooriMasjidAPI.Features.MasjidGullak.Handlers
{
    public class GetGullakQueryHandler : IRequestHandler<GetGullakQuery, IEnumerable<GullakResponseModel>>
    {
        private readonly IMasjidGullakService _gullakService;

        public GetGullakQueryHandler(IMasjidGullakService gullakService)
        {
            _gullakService = gullakService;
        }

        public async Task<IEnumerable<GullakResponseModel>> Handle(GetGullakQuery request, CancellationToken cancellationToken)
        {
            return await _gullakService.GetGullakDataAsync();
        }
    }

}
