namespace SunniNooriMasjidAPI.Features.Models.SadqaMember.Response
{
    public class SadqaMemberResponseModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? MobileNumber { get; set; }
        public int? AddedBy { get; set; }
        public string? AddedByName { get; set; } // Include AddedByName for a user-friendly response
    }
}
