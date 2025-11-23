namespace SunniNooriMasjidAPI.Features.Models.Login.Response
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public int? MemberId { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
