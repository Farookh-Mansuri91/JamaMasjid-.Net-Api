namespace SunniNooriMasjidAPI.Features.Models.MasjidIncomeExpense.Response
{
    public class MasjidIncomeExpenseResponseModel
    {
        public List<IncomeData> Income { get; set; } // Represents the income data
        public List<ExpenseData> Expense { get; set; } // Represents the expense data
    }

    public class IncomeData
    {
        public int Year { get; set; } // Year of the income data
        public decimal MasjidAmount { get; set; } // Amount for Masjid
        public decimal QabristanAmount { get; set; } // Amount for Qabristan
        public decimal MasjidProgram { get; set; } // Amount for Masjid Program
        public decimal Balance { get; set; } // Balance = Total Income - Total Expenses
    }

    public class ExpenseData
    {
        public int? Year { get; set; } // Year of the expense data
        public decimal TotalExpenses { get; set; } // Total expense amount
    }

}
