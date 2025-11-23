using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Interfaces;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;

namespace SunniNooriMasjidAPI.Services.SadqaMemberService
{
    public class SadqaMemberService : ISadqaMemberService
    {
        private readonly IRepository<SadqaMembersPayment> _sadqaMemberPaymentRepository;
        private readonly IRepository<SadqaPayment> _sadqaPaymentRepository;
        //private readonly IRepository<SunniNooriMasjidDbContext> _masjidDBContext;

        public SadqaMemberService(IRepository<SadqaMembersPayment> sadqaMemberPaymentRepository, IRepository<SadqaPayment> sadqaPaymentRepository)
        {
            _sadqaMemberPaymentRepository = sadqaMemberPaymentRepository;
            _sadqaPaymentRepository = sadqaPaymentRepository;
        }

        public async Task<IEnumerable<SadqaMemberResponseModel>> GetSadqaMemberDataAsync()
        {
            // Fetch all data using repository
            var sadqamemberData = await _sadqaMemberPaymentRepository.GetAllAsync();

            // Map the data to the response model or process it as needed
            return sadqamemberData.Select(data => new SadqaMemberResponseModel
            {
                MemberId = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                FatherName = data.FatherName,
                MobileNumber = data.MobileNumber,
              
            });
        }
        // new 
        public async Task<IEnumerable<SadqaMemberPaymentResponseModel>> GetAllSadqaPymentMembersAsync()
        {
            // Get all members and payments asynchronously from their repositories
            var sadqamemberPayment = await _sadqaMemberPaymentRepository.GetAllAsync();
            var sadqapayments = await _sadqaPaymentRepository.GetAllAsync();

            // Process the data and project into the required response model
            var sadqaMemberpayments = (from member in sadqamemberPayment
                                       where member.IsActive == true  // Explicit check for active members
                                       join payment in sadqapayments
                                       on member.Id equals payment.MemberId
                                       select new SadqaMemberPaymentResponseModel
                                       {
                                           Id = member.Id,
                                           FirstName = member.FirstName,
                                           LastName = member.LastName,
                                           FatherName = member.FatherName,
                                           MobileNumber = member.MobileNumber,
                                           Payments = new List<SadqaPaymentResponse>
                                   {
                                       new SadqaPaymentResponse
                                       {
                                           Id = payment.Id,
                                           Month = payment.Month,
                                           Year = payment.Year,
                                           Amount = payment.Amount,
                                           PaymentDate = payment.PaymentDate
                                       }
                                   }
                                       }).ToList(); // Use ToList() here because you're working with in-memory data

            // Return the result
            return sadqaMemberpayments;
        }
        // new 
        public async Task<UpdateSadqaMemberResponseModel> UpdateSadqaPaymentAsync(UpdateSadqaPaymentRequestModel request)
        {
            if (!DateTime.TryParse(request.Payment.PaymentDate, out DateTime parsedPaymentDate))
            {
                throw new ArgumentException("Invalid payment date format");
            }

            // Get payment by condition (it could return null)
            var payment = await _sadqaPaymentRepository.GetByConditionAsync(p => p.MemberId == request.MemberId && p.Id == request.Payment.Id && p.Year == request.Year && p.Month==request.Month);

            if (payment == null)
            {
                return new UpdateSadqaMemberResponseModel
                {
                    Success = false,
                    ErrorMessage = "Sadqa Member not found."
                };
            }

            // Update payment details if found
            payment.Amount = request.Payment.Amount;
            payment.PaymentDate = parsedPaymentDate;
            payment.Year = request.Payment.Year;
            payment.Month = request.Payment.Month;

            _sadqaPaymentRepository.Update(payment);
            await _sadqaPaymentRepository.SaveChangesAsync();

            return  new UpdateSadqaMemberResponseModel  { Success=true};
        }

        // new 
        public async Task<UpdateSadqaMemberResponseModel> AddSadqaPaymentAsync(AddSadqaPaymentRequestModel request)
        {
            if (!DateTime.TryParse(request.PaymentDate, out DateTime parsedPaymentDate))
            {
                throw new ArgumentException("Invalid payment date format");
            }

            try
            {
                // Check if the member exists in the database
                var member = await _sadqaPaymentRepository.GetByConditionAsync(p => p.MemberId == request.MemberId);
                if (member == null)
                {
                    return new UpdateSadqaMemberResponseModel
                    {
                        Success = false,
                        ErrorMessage = "Sadqa Member not found."
                    };
                }

                // Check if a payment already exists for the same member, month, and year
                var existingPayment = await _sadqaPaymentRepository.GetByConditionAsync(p => p.MemberId == request.MemberId && p.Month == request.Month && p.Year == request.Year);

                if (existingPayment != null)
                {
                    return new UpdateSadqaMemberResponseModel
                    {
                        Success = false,
                        ErrorMessage = "Duplicate entry: Payment already exists for the given month and year."
                    };
                }

                // If no duplicate found, create a new payment record
                var newPayment = new SadqaPayment
                {
                    MemberId = request.MemberId,
                    Amount = request.Amount,
                    PaymentDate = parsedPaymentDate,
                    Year = request.Year,
                    Month = request.Month
                };

                // Add the new payment record to the repository
                await _sadqaPaymentRepository.AddAsync(newPayment);
                await _sadqaPaymentRepository.SaveChangesAsync();

                return new UpdateSadqaMemberResponseModel { Success = true };
            }
            catch (Exception ex)
            {
                // Catch any other exceptions and log them if necessary
                return new UpdateSadqaMemberResponseModel
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. " + ex.Message // You can also log the exception here for more details
                };
            }
        }

        public async Task<int> AddSadqaMemberAsync(SadqaMemberRequestModel request)
        {
            // Validate request
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "SadqaMemberRequestModel cannot be null.");
            }

            // Map the request to the entity
            var sadqaMember = new SadqaMembersPayment
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                FatherName = request.FatherName,
                MobileNumber = request.MobileNumber,
             
            };

            // Add to repository
            await _sadqaMemberPaymentRepository.AddAsync(sadqaMember);

            // Save changes to database
            await _sadqaMemberPaymentRepository.SaveChangesAsync();

            // Return the ID of the newly added member
            return sadqaMember.Id;
        }

        public async Task<UpdateSadqaMemberResponseModel> UpdateSadqaMemberAsync(SadqaMemberRequestModel request)
        {
            // Retrieve the existing member
            var member = await _sadqaMemberPaymentRepository.GetByIdAsync(request.MemberId);

            if (member == null)
            {
                return new UpdateSadqaMemberResponseModel
                {
                    Success = false,
                    ErrorMessage = "Sadqa Member not found."
                };
            }

            // Update fields
            member.FirstName = request.FirstName;
            member.LastName = request.LastName;
            member.FatherName = request.FatherName;
            member.MobileNumber= request.MobileNumber;
            // Save changes
            await _sadqaMemberPaymentRepository.SaveChangesAsync();
            return new UpdateSadqaMemberResponseModel { Success = true };
        }

    }
}
