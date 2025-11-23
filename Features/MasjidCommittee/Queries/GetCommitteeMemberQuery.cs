using MediatR;
using SunniNooriMasjidAPI.Features.Models.MasjidCommittee.Response;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;

namespace SunniNooriMasjidAPI.Features.MasjidCommittee.Queries
{
      public class GetCommitteeMemberQuery : IRequest<CommitteeMemberGroupedResponse> { }
}
