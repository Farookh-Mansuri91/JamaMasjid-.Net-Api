using MediatR;

namespace SunniNooriMasjidAPI.Features.Models.SadqaMember.Request
{
    public class UpdateSadqaPaymentRequestModel
    {
        public int MemberId { get; set; }  // memberId
        public int Year { get; set; }  // year of the request
        public string Month { get; set; }  // month of the request
        public PaymentDto Payment { get; set; }  // Payment data
    }
    public class PaymentDto
    {
        public int Id { get; set; }  // Payment ID
        public string Month { get; set; }  // Payment month
        public int Year { get; set; }  // Payment year
        public decimal Amount { get; set; }  // Payment amount
        public string PaymentDate { get; set; }  // Payment date
    }
}
