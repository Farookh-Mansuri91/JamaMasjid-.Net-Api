using MediatR;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.MasjidGullak.Commands;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Request;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Response;
using SunniNooriMasjidAPI.Interfaces;
using SunniNooriMasjidAPI.Interfaces.IMasjidGullak;

namespace SunniNooriMasjidAPI.Services.MasjidGullakService
{
    public class MasjidGullakService : IMasjidGullakService
    {
        private readonly IRepository<MasjidGullakCollection> _gullakRepository;

        public MasjidGullakService(IRepository<MasjidGullakCollection> gullakRepository)
        {
            _gullakRepository = gullakRepository;
        }

        public async Task<IEnumerable<GullakResponseModel>> GetGullakDataAsync()
        {
            // Call repository or any external API and process the data
            var gullakData = await _gullakRepository.GetAllAsync();

            // Optionally process or map data before returning
            return gullakData.Select(data => new GullakResponseModel
            {
                Id = data.Id,
                AmountCollected = data.Amount,
                CollectionDate = data.CollectionDate,
                Remarks = data.Remarks,
                VillageId = data.VillageId,
                CreatedBy=data.CreatedBy,
                UpdatedBy=data.UpdatedBy,

            });
        }

        public async Task<UpdateGullakResponseModel> AddMasjidGullakDataAsync(AddGullakCommand request)
        {
            try
            {
                // Map AddGullakCommand to MasjidGullakCollection
                var newPayment = new MasjidGullakCollection
                {
                    CollectionDate = request.Date,
                    Amount = request.Amount,
                    Remarks = request.Remarks,
                    VillageId = request.VillageId,
                    CreatedBy = request.AddedBy,
                    UpdatedBy = request.AddedBy,
                    CreatedOn = request.AddedOn,
                    UpdatedOn = request.AddedOn
                };

                // Add the new payment record to the repository
                await _gullakRepository.AddAsync(newPayment);
                await _gullakRepository.SaveChangesAsync();

                return new UpdateGullakResponseModel { Success = true };
            }
            catch (Exception ex)
            {
                // Catch any other exceptions and log them if necessary
                return new UpdateGullakResponseModel
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. " + ex.Message // You can also log the exception here for more details
                };
            }

        }
        public async Task<UpdateGullakResponseModel> UpdateMasjidGullakDataAsync(UpdateGullakCommand request)
        {
            try
            {
                // Get payment by condition (it could return null)
                var payment = await _gullakRepository.GetByIdAsync(request.Id);

                if (payment == null)
                {
                    return new UpdateGullakResponseModel
                    {
                        Success = false,
                        ErrorMessage = "Gullak collection record not found."
                    };
                }

                // Update payment details directly on the retrieved entity
                payment.Amount = request.Amount;
                payment.CollectionDate = request.Date;
                payment.Remarks = request.Remarks;
                payment.UpdatedBy = request.UpdatedBy;
                payment.UpdatedOn = request.UpdatedOn;

                // Save changes to the repository
                _gullakRepository.Update(payment);
                await _gullakRepository.SaveChangesAsync();

                return new UpdateGullakResponseModel { Success = true };
            }
            catch (Exception ex)
            {
                return new UpdateGullakResponseModel
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred. " + ex.Message
                };
            }
        }

    }

}
