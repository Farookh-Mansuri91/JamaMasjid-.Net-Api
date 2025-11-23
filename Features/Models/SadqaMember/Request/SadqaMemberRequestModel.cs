namespace SunniNooriMasjidAPI.Features.Models.SadqaMember.Request
{
    public class SadqaMemberRequestModel
    {
     public int MemberId {  get; set; } 
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? MobileNumber { get; set; }

    }
}
