using SunniNooriMasjidAPI.Features.MasjidGullak.Commands;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Request;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;

namespace SunniNooriMasjidAPI.Interfaces.IMasjidGullak
{
    public interface IMasjidGullakService
    {
        public Task<IEnumerable<GullakResponseModel>> GetGullakDataAsync();
        public Task<UpdateGullakResponseModel> AddMasjidGullakDataAsync(AddGullakCommand command);
        public Task<UpdateGullakResponseModel> UpdateMasjidGullakDataAsync(UpdateGullakCommand command);
    }
}
