namespace SunniNooriMasjidAPI.Features.Models.VillageMember.Request
{
    public class VillageMemberRequestModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? FatherName { get; set; }

        public int? MohallaId { get; set; }

        public string? MobileNumber { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get;}
    }
}
