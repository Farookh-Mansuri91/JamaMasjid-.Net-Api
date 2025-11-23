using MediatR;
using SunniNooriMasjidAPI.Features.Login.Queries;
using SunniNooriMasjidAPI.Features.Models.Login.Request;
using SunniNooriMasjidAPI.Features.Models.Login.Response;
using SunniNooriMasjidAPI.Interfaces.ILoginService;

namespace SunniNooriMasjidAPI.Features.Login.Handlers
{
    public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, LoginResponse>
    {
        private readonly ILoginService _loginService;

        public GetLoginQueryHandler(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }

        public async Task<LoginResponse> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "The login request cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                throw new ArgumentException("Username and password must be provided.");
            }

            var loginRequest = new LoginRequest
            {
                Username = request.Username,
                Password = request.Password
            };

            // Assuming _loginService.GetLoginDataAsync handles exceptions internally and can return null or throw.
            var loginResponse = await _loginService.GetLoginDataAsync(loginRequest);

            if (loginResponse == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return loginResponse;
        }
    }

}
