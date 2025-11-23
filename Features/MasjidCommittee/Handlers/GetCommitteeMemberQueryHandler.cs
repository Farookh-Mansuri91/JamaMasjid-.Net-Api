using MediatR;
using SunniNooriMasjidAPI.Features.MasjidCommittee.Queries;
using SunniNooriMasjidAPI.Features.MasjidGullak.Queries;
using SunniNooriMasjidAPI.Features.Models.MasjidCommittee.Response;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;
using SunniNooriMasjidAPI.Interfaces.IMasjidCommittee;
using SunniNooriMasjidAPI.Interfaces.IMasjidGullak;

namespace SunniNooriMasjidAPI.Features.MasjidCommittee.Handlers
{

    public class GetCommitteeMemberQueryHandler : IRequestHandler<GetCommitteeMemberQuery, CommitteeMemberGroupedResponse>
    {
        private readonly IMasjidCommitteeService _committeeService;

        public GetCommitteeMemberQueryHandler(IMasjidCommitteeService committeeService)
        {
            _committeeService = committeeService;
        }

        public async Task<CommitteeMemberGroupedResponse> Handle(GetCommitteeMemberQuery request, CancellationToken cancellationToken)
        {
            return await _committeeService.GetCommitteeMemberDataAsync();
        }
    }
}
