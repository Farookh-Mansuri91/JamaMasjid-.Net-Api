using MediatR;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Handlers
{
    public class UpdateSadqaMemberCommandHandler : IRequestHandler<UpdateSadqaMemberCommand, UpdateSadqaMemberResponseModel>
    {
        private readonly ISadqaMemberService _sadqaMemberService;

        public UpdateSadqaMemberCommandHandler(ISadqaMemberService sadqaMemberService)
        {
            _sadqaMemberService = sadqaMemberService;
        }
        public async Task<UpdateSadqaMemberResponseModel> Handle(UpdateSadqaMemberCommand request, CancellationToken cancellationToken)
        {
            return await _sadqaMemberService.UpdateSadqaMemberAsync(request.SadqaMemberRequest);
        }
    }
}
