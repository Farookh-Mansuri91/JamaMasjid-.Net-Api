using Microsoft.EntityFrameworkCore;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.Models.VillageMember.DTO;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Request;
using SunniNooriMasjidAPI.Features.Models.VillageMember.Response;
using SunniNooriMasjidAPI.Features.VillageMember.Commands;
using SunniNooriMasjidAPI.Interfaces;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;

namespace SunniNooriMasjidAPI.Services.VillageMemberService
{
    public class VillageMemberService : IVillageMemberService
    {
        //private readonly IRepository<Villagemember> _villagememberRepository;
        private readonly IRepository<VillageMembersPayment> _villagememberPaymentRepository;
        private readonly IRepository<SalaryPayment> _salaryPaymentRepository;
        private readonly IRepository<Mohalla> _mohallaRepository;
        private readonly SunniNooriMasjidDbContext _masjidDBContext;  // DbContext for accessing Mohalla table

        // Injecting DbContext in constructor
        public VillageMemberService(IRepository<Villagemember> villagememberRepository, IRepository<Mohalla> mohallaRepository, IRepository<SalaryPayment> salaryPaymentRepository,
            IRepository<VillageMembersPayment> villagememberPaymentRepository, SunniNooriMasjidDbContext context)
        {
            //_villagememberRepository = villagememberRepository;
            _villagememberPaymentRepository = villagememberPaymentRepository;
            _mohallaRepository = mohallaRepository;
            _salaryPaymentRepository = salaryPaymentRepository;
            _masjidDBContext = context;  // Assuming DbContext is being injected
        }

        public async Task<IEnumerable<VillageMemberResponseModel>> GetVillageMemberDataAsync()
        {
            // Use the repository to fetch data
            var villagememberData = await _villagememberPaymentRepository.GetAllAsync();

            // Perform the join with the Mohalla table
            var villageMembersWithMohalla = villagememberData.Join(
                _masjidDBContext.Set<Mohalla>(),  // Access the Mohalla DbSet from the DbContext
                vm => vm.MohallaId,               // Key selector for Villagemember
                m => m.MohallaId,                 // Key selector for Mohalla
                (vm, m) => new VillageMemberResponseModel
                {
                    Id = vm.MemberId,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    FatherName = vm.FatherName,
                    MohallaId = vm.MohallaId,
                    MohallaName = m.MohallaName,  // Assuming 'MohallaName' is the correct property name in Mohalla
                    MobileNumber = vm.MobileNumber,
                    UserId = vm.MemberId
                }).ToList();

            return villageMembersWithMohalla;
        }
        public async Task<int> AddVillageMemberAsync(VillageMemberRequestModel request, int createdBy)
        {
            // Validate request
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "VillageMemberRequestModel cannot be null.");
            }

            // Map the request to the entity
            var villageMember = new VillageMembersPayment
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                FatherName = request.FatherName,
                MohallaId = request.MohallaId,
                MobileNumber = request.MobileNumber,
                CreatedBy = createdBy
            };

            // Add to repository
            await _villagememberPaymentRepository.AddAsync(villageMember);

            // Save changes to database
            await _villagememberPaymentRepository.SaveChangesAsync();

            // Return the ID of the newly added member
            return villageMember.MemberId;
        }

        public async Task<UpdateVillageMemberResponseModel> UpdateVillageMemberAsync(VillageMemberRequestModel request, int updatedBy)
        {
            // Retrieve the existing member
            var member = await _villagememberPaymentRepository.GetByIdAsync(request.Id);

            if (member == null)
            {
                return new UpdateVillageMemberResponseModel
                {
                    Success = false,
                    ErrorMessage = "Sadqa Member not found."
                };
            }

            // Update fields
            member.FirstName = request.FirstName;
            member.LastName = request.LastName;
            member.FatherName = request.FatherName;
            member.MohallaId = request.MohallaId;
            member.MobileNumber = request.MobileNumber;
            member.UpdatedBy = updatedBy;
            // Save changes
            await _villagememberPaymentRepository.SaveChangesAsync();
            return new UpdateVillageMemberResponseModel { Success = true };
        }


        public async Task<List<VillageMemberDTO>> GetMembersPaymentAsync()
        {
            // Fetch all members and their payments without filtering by year.
            var query = _masjidDBContext.VillageMembersPayments
                .Select(m => new VillageMemberDTO
                {
                    MemberId = m.MemberId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    FatherName = m.FatherName,
                    Payments = m.SalaryPayments
                        .Select(p => new PaymentDTO
                        {
                            PaymentId = p.PaymentId,
                            Amount = p.Amount,
                            PaymentDate = p.PaymentDate
                        })
                        .ToList()
                });

            // Execute the query and return the results as a list.
            return await query.ToListAsync();
        }
        public async Task<bool> UpdatePaymentAsync(int memberId, int paymentId, decimal amount, string paymentDate, int year)
        {
            // Parse the paymentDate string into DateTime
            DateTime parsedPaymentDate;
            if (!DateTime.TryParse(paymentDate, out parsedPaymentDate))
            {
                return false; // Return false if the date format is invalid
            }

            // Find the payment record by memberId, paymentId and year
            var payment = await _masjidDBContext.SalaryPayments
                .FirstOrDefaultAsync(p => p.MemberId == memberId && p.PaymentId == paymentId && p.PaymentDate.Year == year);

            if (payment != null)
            {
                // Update the payment details
                payment.Amount = amount;
                payment.PaymentDate = parsedPaymentDate;

                // Save changes to the database
                _masjidDBContext.SalaryPayments.Update(payment);
                await _masjidDBContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<int> AddPaymentAsync(AddPaymentCommand command)
        {
            var payment = new SalaryPayment
            {
                MemberId = command.MemberId,
                Amount = command.Amount,
                PaymentDate = command.PaymentDate,
                Year = command.Year
            };

            await _salaryPaymentRepository.AddAsync(payment);
            await _salaryPaymentRepository.SaveChangesAsync();

            if (!payment.MemberId.HasValue)
            {
                throw new InvalidOperationException("The MemberId cannot be null.");
            }

            return payment.MemberId.Value; // Use .Value to extract the value of a nullable int
        }

        public async Task<IEnumerable<VillageMohallaResponseModel>> GetMohallaDataAsync()
        {
            try
            {
                // Fetch data from the repository
                var mohallaData = await _mohallaRepository.GetAllAsync();

                // Ensure the fetched data is not null
                if (mohallaData == null)
                {
                    return Enumerable.Empty<VillageMohallaResponseModel>();
                }

                // Map the fetched data to the response model
                var villageMohalla = mohallaData.Select(m => new VillageMohallaResponseModel
                {
                    MohallaId = m.MohallaId,
                    MohallaName = m.MohallaName
                }).ToList();

                return villageMohalla;
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
                // Optionally rethrow or return an empty list
                throw new Exception("Error fetching mohalla data", ex);
            }
        }

    }
}
