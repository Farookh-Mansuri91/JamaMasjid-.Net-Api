namespace SunniNooriMasjidAPI.Features.Models.VillageMember.DTO
{
    public class VillageMemberDTO
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public List<PaymentDTO> Payments { get; set; }
    }
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
