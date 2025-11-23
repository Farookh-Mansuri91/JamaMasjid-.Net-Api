namespace SunniNooriMasjidAPI.Features.Models.YearlyIncome.Request
{
    public class MasjidIncomeRequestModel
    {
        public int VillageMemberId { get; set; }
        public int Year { get; set; }
        public decimal MasjidAmount { get; set; }
        public decimal QabristanAmount { get; set; }
        public decimal MasjidProgramAmount { get; set; }
        public string PaymentDate { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedOn { get; set; }
        
    }
}
