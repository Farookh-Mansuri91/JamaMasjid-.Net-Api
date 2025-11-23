using SunniNooriMasjidAPI.Features.Models.Login.Request;
using SunniNooriMasjidAPI.Features.Models.Login.Response;

namespace SunniNooriMasjidAPI.Interfaces.ILoginService
{
    public interface ILoginService
    {
        public  Task<LoginResponse> GetLoginDataAsync(LoginRequest request);
    }
}
