namespace SunniNooriMasjidAPI.Features.Models.MasjidCommittee.Response
{
    public class CommitteeMemberResponseModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? FatherName { get; set; }

        public string? MobileNumber { get; set; }

        public string? MemberPic { get; set; }

        public DateTime? JoiningDate { get; set; } // Convert DateTime to string for API-friendly format

        public string? MohallaName { get; set; } // Include related Mohalla's name if available

        public string? RoleName { get; set; } // Include Role's name

        public bool IsActive { get; set; }
        public string? MemberType { get; set;}
    }

    public class CommitteeMemberGroupedResponse
    {
        public List<CommitteeMemberResponseModel> RegularMembers { get; set; } = new();
        public List<CommitteeMemberResponseModel> SpecialMembers { get; set; } = new();
        public List<ImamHistoryResponseModel> ImamHistory { get; set;} = new();
    }
}
