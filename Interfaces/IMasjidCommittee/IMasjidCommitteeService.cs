using SunniNooriMasjidAPI.Features.Models.MasjidCommittee.Response;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;

namespace SunniNooriMasjidAPI.Interfaces.IMasjidCommittee
{
    public interface IMasjidCommitteeService
    {
        public Task<CommitteeMemberGroupedResponse> GetCommitteeMemberDataAsync();
    }
}
