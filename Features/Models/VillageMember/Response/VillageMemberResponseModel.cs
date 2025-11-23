namespace SunniNooriMasjidAPI.Features.Models.VillageMember.Response
{
    public class VillageMemberResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? FatherName { get; set; }

        public int? MohallaId { get; set; }

        public string? MobileNumber { get; set; }

        public decimal? Amount { get; set; }

        public string? Caste { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? UserId { get; set; }

        // The response model may include a simpler representation of the related entities like Mohalla and Member if needed
        public string? MohallaName { get; set; }  // You could replace this with actual properties from the Mohalla entity

        public string? MemberName { get; set; }  // You can create a full name for the member based on the user ID or other attributes
    }
}
