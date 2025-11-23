using MediatR;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;

namespace SunniNooriMasjidAPI.Features.SadqaMember.Handlers
{
    public class AddSadqaMemberCommandHandler : IRequestHandler<AddSadqaMemberCommand, int>
    {
        private readonly ISadqaMemberService _sadqaMemberService;

        public AddSadqaMemberCommandHandler(ISadqaMemberService sadqaMemberService)
        {
            _sadqaMemberService = sadqaMemberService;
        }

        public async Task<int> Handle(AddSadqaMemberCommand request, CancellationToken cancellationToken)
        {
            return await _sadqaMemberService.AddSadqaMemberAsync(request.SadqaMemberRequest);
        }
    }
}
