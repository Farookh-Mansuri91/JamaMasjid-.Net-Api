using Microsoft.EntityFrameworkCore;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.Models.MasjidIncomeExpense.Response;
using SunniNooriMasjidAPI.Interfaces.IMasjidIncomeExpense;

namespace SunniNooriMasjidAPI.Services.MasjidIncomeExpenseService
{
    public class MasjidIncomeExpenseService : IMasjidIncomeExpenseService
    {
        private readonly SunniNooriMasjidDbContext _masjidDBcontext;

        public MasjidIncomeExpenseService(SunniNooriMasjidDbContext masjidDBcontext)
        {
            _masjidDBcontext = masjidDBcontext;
        }
        public async Task<IEnumerable<MasjidIncomeExpenseResponseModel>> GetIncomeExpenseDataAsync()
        {
            // Get income data and sum the amounts for each year
            var incomeData = await _masjidDBcontext.Masjidincomes
                .GroupBy(i => i.Year) // Group by Year
                .Select(g => new IncomeData
                {
                    Year = g.Key,
                    MasjidAmount = g.Sum(i => i.MasjidAmount), // Sum MasjidAmount per year
                    QabristanAmount = g.Sum(i => i.QabristanAmount), // Sum QabristanAmount per year
                    MasjidProgram = g.Sum(i => i.MasjidProgamAmount), // Sum MasjidProgram per year
                })
                .ToListAsync();

            // Get expense data and sum the total expenses for each year
            var expenseData = await _masjidDBcontext.Masjidyearlyexpenses
                .GroupBy(e => e.Year) // Group by Year
                .Select(g => new ExpenseData
                {
                    Year = g.Key,
                    TotalExpenses = g.Sum(e => e.Amount) // Sum TotalExpenses per year
                })
                .ToListAsync();

            // Now we calculate the balance for each income entry by matching with the corresponding expense year
            foreach (var income in incomeData)
            {
                var correspondingExpense = expenseData.FirstOrDefault(e => e.Year == income.Year);

                // If there is no matching expense data for that year, assume 0 for expenses
                decimal totalExpenses = correspondingExpense?.TotalExpenses ?? 0;

                // Calculate the balance: Total Income - Total Expenses
                income.Balance = (income.MasjidAmount + income.QabristanAmount + income.MasjidProgram) - totalExpenses;
            }

            // Create the response model and return it
            var response = new List<MasjidIncomeExpenseResponseModel>
    {
        new MasjidIncomeExpenseResponseModel
        {
            Income = incomeData,
            Expense = expenseData
        }
    };

            return response;
        }

    }
}
