using MediatR;

namespace SunniNooriMasjidAPI.Features.VillageMember.Commands
{
    public class UpdatePaymentCommand : IRequest<bool>
    {
        public int MemberId { get; set; }
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentDate { get; set; }
        public int Year { get; set; }

        public UpdatePaymentCommand(int memberId, decimal amount, string paymentDate, int year, int paymentId)
        {
            MemberId = memberId;
            Amount = amount;
            PaymentDate = paymentDate;
            Year = year;
            PaymentId = paymentId;
        }
    }
}
