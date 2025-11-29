using Microsoft.EntityFrameworkCore;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.DTO;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Request;
using SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response;
using SunniNooriMasjidAPI.Interfaces;
using SunniNooriMasjidAPI.Interfaces.IYearlyIncome;

namespace SunniNooriMasjidAPI.Services.YearlyIncomeService
{
    public class YearlyIncomeService : IYearlyIncomeService
    {
       // private readonly IRepository<Masjidyearlyincome> _yearlyincomeRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Villagemember> _villageMemberRepository;
        private readonly IRepository<Mohalla> _mohallaRepository;
        private readonly IRepository<Masjidgullak> _gullakRepository;
        private readonly IRepository<Masjidincome> _masjidIncome;
        private readonly IRepository<User> _userRepository;
        private readonly SunniNooriMasjidDbContext _masjidDBContext;


        public YearlyIncomeService(
            IRepository<Member> memberRepository,
            IRepository<Villagemember> villagememberRepository,
            IRepository<Mohalla> mohallaRepository,
            IRepository<User> userRepository,
            IRepository<Masjidincome> masjidIncome,
            IRepository<Masjidgullak> gullakRepository,
            SunniNooriMasjidDbContext masjidDBContext)
        {
            _memberRepository = memberRepository;
            _villageMemberRepository = villagememberRepository;
            _mohallaRepository = mohallaRepository;
            _userRepository = userRepository;
            _gullakRepository = gullakRepository;
            _masjidIncome = masjidIncome;
            _masjidDBContext = masjidDBContext;
        }

        //public async Task<IEnumerable<YearlyIncomeResponseModel>> GetYearlyIncomeAsync(int year)
        //{
        //    // Fetch all necessary data asynchronously
        //    var memberData = await _memberRepository.GetAllAsync();
        //    var villageMemberData = await _villageMemberRepository.GetAllAsync();
        //    var mohallaData = await _mohallaRepository.GetAllAsync();
        //    var yearlyIncomeData = await _yearlyincomeRepository.GetAllAsync();
        //    var gullakYearlyData = await _gullakRepository.GetAllAsync();

        //    // Filter data for the specified year
        //    var yearlyIncomeFiltered = yearlyIncomeData
        //        .Where(yi => yi.PaymentDate.Year == year);

        //    var gullakYearlyFiltered = gullakYearlyData
        //        .Where(g => g.CollectionDate.Year == year);

        //    // Calculate totals
        //    var totalMasjidAmount = yearlyIncomeFiltered.Sum(y => y.MasjidIncome);
        //    var totalQabaristanAmount = yearlyIncomeFiltered.Sum(y => y.QabristaanIncome);
        //    var totalMasjidProgramAmount = yearlyIncomeFiltered.Sum(y => y.MasjidProgramIncome);
        //    var totalMasjidGullakAmount = gullakYearlyFiltered.Sum(g => g.Amount);
        //    var grandTotalAmount = yearlyIncomeFiltered.Sum(y =>
        //        y.MasjidIncome + y.QabristaanIncome + y.MasjidProgramIncome);

        //    // Build the response using LINQ
        //    var yearlyIncomeQuery = from vm in villageMemberData
        //                            join yi in yearlyIncomeFiltered on vm.Id equals yi.VillageMemberId
        //                            join m in memberData on vm.MemberId equals m.Id
        //                            join mo in mohallaData on yi.MohallaId equals mo.MohallaId
        //                            select new YearlyIncomeResponseModel
        //                            {
        //                                Id = yi.IncomeId,
        //                                Name = vm.FirstName,
        //                                FatherName = vm.FatherName,
        //                                MohallaName = mo.MohallaName,
        //                                Caste = vm.Caste,
        //                                PaymentDate = yi.PaymentDate,
        //                                MasjidAmount = yi.MasjidIncome,
        //                                QabristaanAmount = yi.QabristaanIncome,
        //                                MasjidProgramAmount = yi.MasjidProgramIncome,
        //                                Remarks = yi.Remarks,
        //                                TotalMasjidAmount = totalMasjidAmount,
        //                                TotalQabaristan = totalQabaristanAmount,
        //                                TotalMasjidProgramAmount = totalMasjidProgramAmount,
        //                                TotalMasjidGullakAmount = totalMasjidGullakAmount,
        //                                GrandtotalAmount = grandTotalAmount
        //                            };

        //    return yearlyIncomeQuery.ToList();

        //    //return   await Task.FromResult(Enumerable.Empty<YearlyIncomeResponseModel>());

        //}

        public async Task<List<MasjidYearlyIncomeDTO>> GetVillageMasjidYearlyIncomeAsync()
        {
            // Load all users first to map CreatedBy → Username
            var users = await _userRepository.GetAllAsync();
            var userDict = users.ToDictionary(x => x.Id, x => x.Username);

            var query = _masjidDBContext.VillageMembersPayments
                .Select(m => new MasjidYearlyIncomeDTO
                {
                    VillageMemberId = m.MemberId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    FatherName = m.FatherName,

                    MasjidIncome = m.Masjidincomes
                        .Select(p => new MasjidIncomeDTO
                        {
                            Id = p.Id,
                            MasjidAmount = p.MasjidAmount,
                            QabristanAmount = p.QabristanAmount,
                            MasjidProgramAmount = p.MasjidProgamAmount,
                            PaymentDate = p.PaymentDate.ToString("yyyy-MM-dd"),

                            // 👇 Main Logic: Convert CreatedBy → Username (PaidTo)
                            PaidTo = p.CreatedBy != null
                                     && userDict.ContainsKey(p.CreatedBy.Value)
                                     ? userDict[p.CreatedBy.Value]
                                     : "Unknown"
                        })
                        .ToList()
                });

            return await query.ToListAsync();
        }




        public async Task<MasjidIncomeResponseModel> AddMasjidIncomePaymentAsync(MasjidIncomeRequestModel request)
        {
            if (!DateTime.TryParse(request.PaymentDate, out DateTime parsedPaymentDate))
            {
                throw new ArgumentException("Invalid payment date format");
            }
            try
            {
                var newPayment = new Masjidincome
                {
                    VillageMemberId = request.VillageMemberId,
                    Year = request.Year,
                    MasjidAmount = request.MasjidAmount,
                    QabristanAmount = request.QabristanAmount,
                    MasjidProgamAmount = request.MasjidProgramAmount,
                    PaymentDate = parsedPaymentDate,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = DateTime.Now
                };

                // Add the new payment record to the repository
                await _masjidIncome.AddAsync(newPayment);
                await _masjidIncome.SaveChangesAsync();

                return new MasjidIncomeResponseModel { Success = true };
            }
            catch (Exception ex)
            {
                // Catch any other exceptions and log them if necessary
                return new MasjidIncomeResponseModel
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. " + ex.Message // You can also log the exception here for more details
                };
            }
        }
        public async Task<MasjidIncomeResponseModel> UpdateMasjidIncomePaymentAsync(MasjidIncomeDTO request)
        {
            if (!DateTime.TryParse(request.PaymentDate, out DateTime parsedPaymentDate))
            {
                throw new ArgumentException("Invalid payment date format");
            }
            // Get payment by condition (it could return null)
            var payment = await _masjidIncome.GetByConditionAsync(p => p.Id == request.PaymentId && p.Year == request.Year);

            if (payment == null)
            {
                return new MasjidIncomeResponseModel
                {
                    Success = false,
                    ErrorMessage = "Payment details not found."
                };
            }

            // Update payment details if found
            payment.MasjidAmount = request.MasjidAmount;
            payment.QabristanAmount = request.QabristanAmount;
            payment.MasjidProgamAmount = request.MasjidProgramAmount;
            payment.PaymentDate = parsedPaymentDate;
            payment.Year = request.Year;
            _masjidIncome.Update(payment);
            await _masjidIncome.SaveChangesAsync();

            return new MasjidIncomeResponseModel { Success = true };
        }
    }
}
