namespace SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request
{
    public class AddUpdateExpenseRequestModel
    {
        public int Id { get; set; }
        public string ExpenseDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string PaidTo { get; set; }
        public int PaidBy { get; set; }
        public int Year { get; set; }
    }
}
