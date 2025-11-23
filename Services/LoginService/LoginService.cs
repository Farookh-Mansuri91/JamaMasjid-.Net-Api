using Microsoft.IdentityModel.Tokens;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.Models.Login.Response;
using SunniNooriMasjidAPI.Interfaces.ILoginService;
using SunniNooriMasjidAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SunniNooriMasjidAPI.Features.Models.Login.Request;

public class LoginService : ILoginService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Role> _roleRepository;
    private readonly IRepository<Member> _memberRepository;
    private readonly string _secretKey;

    public LoginService(IRepository<User> userRepository, IRepository<Role> roleRepository, IRepository<Member> memberRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _memberRepository = memberRepository;
        _secretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException("SecretKey is not configured");
    }

    public async Task<LoginResponse> GetLoginDataAsync(LoginRequest request)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ArgumentException("Username and password are required.");
        }

        // Step 1: Fetch all users, roles, and members asynchronously
        var usersData = await _userRepository.GetAllAsync();
        var rolesData = await _roleRepository.GetAllAsync();
        var memberData = await _memberRepository.GetAllAsync();

        // Step 2: Authenticate user using LINQ join
        var user = (from ud in usersData
                    join md in memberData on ud.MemberId equals md.Id
                    join rd in rolesData on md.RoleId equals rd.RoleId
                    where ud.Username == request.Username && ud.Password == request.Password
                    select new
                    {
                        ud.Username,
                        Role = rd.RoleName,
                        MemberId = md.Id,
                        ud.Id
                    }).FirstOrDefault();


        // Step 4: Create claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.MemberId.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.NameIdentifier, user.MemberId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Step 5: Generate JWT token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: "YourIssuer",
            audience: "YourAudience",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: creds
        );

        return new LoginResponse
        {
            UserName = user.Username,
            UserId = user.Id,
            MemberId = user.MemberId,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Role = user.Role
        };
    }
}
