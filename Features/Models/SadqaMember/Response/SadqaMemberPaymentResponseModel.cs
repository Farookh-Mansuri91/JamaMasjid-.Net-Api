namespace SunniNooriMasjidAPI.Features.Models.SadqaMember.Response
{
 
    public class SadqaMemberPaymentResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MobileNumber { get; set; }
        public int? MohallaId { get; set; }
        public int? VillageId { get; set; }
        public bool IsActive { get; set; }
        public List<SadqaPaymentResponse> Payments { get; set; } = new List<SadqaPaymentResponse>();
    }

    public class SadqaPaymentResponse
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
