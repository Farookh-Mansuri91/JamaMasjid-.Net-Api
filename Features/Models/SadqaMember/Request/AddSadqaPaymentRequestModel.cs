namespace SunniNooriMasjidAPI.Features.Models.SadqaMember.Request
{
    public class AddSadqaPaymentRequestModel
    {
        public int MemberId { get; set; }  // Member ID
        public string Month { get; set; }  // Payment month
        public int Year { get; set; }  // Payment year
        public decimal Amount { get; set; }  // Payment amount
        public string PaymentDate { get; set; }  // Payment date
    }
}
