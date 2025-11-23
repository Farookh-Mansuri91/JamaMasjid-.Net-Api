using MediatR;
using SunniNooriMasjidAPI.Features.Models.Login.Response;

namespace SunniNooriMasjidAPI.Features.Login.Queries
{
    public class GetLoginQuery : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public GetLoginQuery(string username, string password)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username), "Username cannot be null.");
            Password = password ?? throw new ArgumentNullException(nameof(password), "Password cannot be null.");
        }
    }

}
