using MediatR;

namespace SunniNooriMasjidAPI.Features.VillageMember.Commands
{
    public class AddPaymentCommand : IRequest<int>
    {
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Year { get; set; }
    }
}
