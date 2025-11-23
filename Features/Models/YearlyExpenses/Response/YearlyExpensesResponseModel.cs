namespace SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response
{
    public class YearlyExpensesResponseModel
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? Year { get; set; }
        public string Category { get; set; }    
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string PaidTo { get; set; }
        public int? PaidBy {  get; set; }

    }

    public class ExpenseResponseWrapper
    {
        public List<YearlyExpensesResponseModel> YearlyExpenses { get; set; }
        public decimal TotalExpenses { get; set; }
    }
}
