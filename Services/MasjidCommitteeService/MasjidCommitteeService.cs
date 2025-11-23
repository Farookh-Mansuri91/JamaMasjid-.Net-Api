using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.Models.MasjidCommittee.Response;
using SunniNooriMasjidAPI.Interfaces;
using SunniNooriMasjidAPI.Interfaces.IMasjidCommittee;

namespace SunniNooriMasjidAPI.Services.MasjidCommitteeService
{
    public class MasjidCommitteeService : IMasjidCommitteeService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Masjidimam> _masjidImamRepository;
        private readonly IRepository<Imamhistory> _imamHistoryRepository;
        private readonly SunniNooriMasjidDbContext _masjidDBContext;  // DbContext for accessing Mohalla table

        public MasjidCommitteeService(IRepository<Member> memberRepository, IRepository<Masjidimam> masjidImamRepository, IRepository<Imamhistory> imamHistoryRepository,
            SunniNooriMasjidDbContext masjidDBContext)
        {
            _memberRepository = memberRepository;
            _masjidDBContext = masjidDBContext;
            _masjidImamRepository = masjidImamRepository;
            _imamHistoryRepository = imamHistoryRepository;
        }

        public async Task<CommitteeMemberGroupedResponse> GetCommitteeMemberDataAsync()
        {
            // Get all member data from the repository
            var memberData = await _memberRepository.GetAllAsync();
            var masjidImam = await _masjidImamRepository.GetAllAsync();
            var imamHistoryData = await _imamHistoryRepository.GetAllAsync();

            // Perform the join with the Mohalla and Role tables using LINQ query syntax
            var membersWithDetails = (from member in memberData
                                      where member.IsActive == true
                                      join mohalla in _masjidDBContext.Set<Mohalla>()
                                      on member.MohallaId equals mohalla.MohallaId into mohallaGroup
                                      from mohalla in mohallaGroup.DefaultIfEmpty()
                                      join role in _masjidDBContext.Set<Role>()
                                      on member.RoleId equals role.RoleId into roleGroup
                                      from role in roleGroup.DefaultIfEmpty()
                                      select new CommitteeMemberResponseModel
                                      {
                                          Id = member.Id,
                                          Name = member.Name,
                                          FatherName = member.FatherName,
                                          MobileNumber = member.MobileNumber,
                                          MemberPic = member.MemberPic,
                                          JoiningDate = member.JoiningDate,
                                          MohallaName = mohalla != null ? mohalla.MohallaName : null,
                                          RoleName = role != null ? role.RoleName : null,
                                          IsActive = member.IsActive,
                                          MemberType = member.MohallaId == null ? "SpecialMember" : "RegularMember"
                                      }).ToList();

            var imamHistoryDetails = (from imam in masjidImam
                                      join imamHistory in imamHistoryData
                                      on imam.Id equals imamHistory.ImamId
                                      select new ImamHistoryResponseModel
                                      {
                                          ImamId = imam.Id,
                                          ImamName = imam.ImamName,
                                          FatherName = imam.FatherName,
                                          JoiningDate = imam.JoinedDate,
                                          MasjidAddress = imam.Address,
                                          City = imam.City,
                                          LastServingDate = imam.LastServingDay,
                                          TotalService = imam.TotalService,
                                          salary = imam.Salary,
                                          ContactNumber = imam.ContactNumber,
                                          Education = imam.Education,
                                          ImamBio = imam.Bio,
                                          ImamImage = imam.Image,
                                          ImamVision = imam.Vision,
                                          Remarks = imamHistory.Remarks,
                                          RoleDescription = imamHistory.RoleDescription
                                      }).ToList();

            // Group members into Regular and Special categories
            var groupedResponse = new CommitteeMemberGroupedResponse
            {
                RegularMembers = membersWithDetails.Where(m => m.MemberType == "RegularMember").ToList(),
                SpecialMembers = membersWithDetails.Where(m => m.MemberType == "SpecialMember").ToList(),
                ImamHistory = imamHistoryDetails.ToList()
            };

            return groupedResponse;
        }


    }
}
