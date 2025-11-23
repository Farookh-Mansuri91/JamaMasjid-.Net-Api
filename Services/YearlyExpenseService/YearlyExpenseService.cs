using MediatR;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyExpenses.Response;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;
using SunniNooriMasjidAPI.Interfaces;
using SunniNooriMasjidAPI.Interfaces.IYearlyExpense;

namespace SunniNooriMasjidAPI.Services.YearlyExpenseService
{
    public class YearlyExpenseService : IYearlyExpenseService
    {
        private readonly IRepository<Masjidyearlyexpense> _yearlyexpensesRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly SunniNooriMasjidDbContext _masjidDBContext;

        public YearlyExpenseService(
            IRepository<Member> memberRepository, IRepository<Masjidyearlyexpense> yearlyexpensesRepository,
            SunniNooriMasjidDbContext masjidDBContext)
        {
            _memberRepository = memberRepository;
            _yearlyexpensesRepository = yearlyexpensesRepository;
            _masjidDBContext = masjidDBContext;
        }
        public async Task<ExpenseResponseWrapper> GetYearlyExpenseAsync(int year)
        {
            // Fetch all necessary data asynchronously
            var memberData = await _memberRepository.GetAllAsync();
            var yearlyExpensesData = await _yearlyexpensesRepository.GetAllAsync();

            // Filter data for the specified year
            var yearlyExpensesFiltered = yearlyExpensesData
                .Where(yi => yi.CollectionDate.Year == year);

            // Calculate totals
            var totalMasjidExpensesAmount = yearlyExpensesFiltered.Sum(y => y.Amount);


            // Build the response using LINQ
            var yearlyExpensesQuery = from ye in yearlyExpensesData
                                      join md in memberData on ye.MemberId equals md.Id
                                      where ye.CollectionDate.Year == year // Apply year filter here
                                      orderby ye.CollectionDate ascending // Apply order by date ascending
                                      select new YearlyExpensesResponseModel
                                      {
                                          Id = ye.Id,
                                          ExpenseDate = ye.CollectionDate,
                                          Year = ye.Year,
                                          Category = ye.Category,
                                          Description = ye.Description,
                                          Amount = ye.Amount,
                                          PaidTo = ye.PaidTo,
                                          PaidBy = md.Id,
                                      };

            return new ExpenseResponseWrapper
            {
                YearlyExpenses = yearlyExpensesQuery.ToList(),
                TotalExpenses = totalMasjidExpensesAmount
            };


        }

        public async Task<AddUpdateExpenseResponseModel> AddYearlyExpenseAsync(AddUpdateExpenseRequestModel request)
        {

            if (!DateTime.TryParse(request.ExpenseDate, out DateTime parsedPaymentDate))
            {
                throw new ArgumentException("Invalid payment date format");
            }
            try
            {
                var newExpense = new Masjidyearlyexpense
                {
                    CollectionDate = parsedPaymentDate,
                    Year = request.Year,
                    Amount = request.Amount,
                    PaidTo = request.PaidTo,
                    MemberId = request.PaidBy,
                    Category = request.Category,
                    Description = request.Description,
                };

                // Add the new payment record to the repository
                await _yearlyexpensesRepository.AddAsync(newExpense);
                await _yearlyexpensesRepository.SaveChangesAsync();

                return new AddUpdateExpenseResponseModel { Success = true };
            }
            catch (Exception ex)
            {
                // Catch any other exceptions and log them if necessary
                return new AddUpdateExpenseResponseModel
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. " + ex.Message // You can also log the exception here for more details
                };
            }
        }
        public async Task<AddUpdateExpenseResponseModel> UpdateYearlyExpenseAsync(AddUpdateExpenseRequestModel request)
        {
            if (!DateTime.TryParse(request.ExpenseDate, out DateTime parsedPaymentDate))
            {
                throw new ArgumentException("Invalid payment date format");
            }
            try
            {
                // Get expense by condition (it could return null)
                var expense = await _yearlyexpensesRepository.GetByIdAsync(request.Id);

                if (expense == null)
                {
                    return new AddUpdateExpenseResponseModel
                    {
                        Success = false,
                        ErrorMessage = "Expense details not found."
                    };
                }

                // Update expense details if found
                expense.CollectionDate = parsedPaymentDate;
                expense.Amount = request.Amount;
                expense.Year = request.Year;
                expense.Category = expense.Category;
                expense.Description = request.Description;
                expense.PaidTo = request.PaidTo;
                expense.MemberId = request.PaidBy;
                _yearlyexpensesRepository.Update(expense);
                await _yearlyexpensesRepository.SaveChangesAsync();

                return new AddUpdateExpenseResponseModel { Success = true };
            }
            catch (Exception ex)
            {
                // Catch any other exceptions and log them if necessary
                return new AddUpdateExpenseResponseModel
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. " + ex.Message // You can also log the exception here for more details
                };
            }

        }
    }

}
