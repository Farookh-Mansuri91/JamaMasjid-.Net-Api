namespace SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO
{

    public class MasjidYearlyIncomeDTO
    {
        public int VillageMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public List<MasjidIncomeDTO> MasjidIncome { get; set; }
    }
    public class MasjidIncomeDTO
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public decimal MasjidAmount { get; set; }
        public decimal QabristanAmount { get; set; }
        public decimal MasjidProgramAmount { get; set; }
        public string PaymentDate { get; set; }
        public int Year {  get; set; }
        public string? PaidTo { get; set; }
    }
}
