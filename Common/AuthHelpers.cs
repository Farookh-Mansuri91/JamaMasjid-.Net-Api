using System.Security.Claims;

namespace SunniNooriMasjidAPI.Common
{
    public static class AuthHelpers
    {
        public static int? GetUserIdFromClaims(ClaimsPrincipal user)
        {
            //// Find the claim of type 'sub' (subject), which holds the MemberId in our case
            //var userIdClaim = user.FindFirst(JwtRegisteredClaimNames.Sub); // This is where the MemberId is stored

            // Finding the claim with the type ClaimTypes.NameIdentifier (usually stores the UserId)
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            // If the claim exists and the value can be parsed as an integer, return the UserId
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;  // Successfully parsed the UserId as an integer
            }

            return null;  // Return null if the claim doesn't exist or parsing failed
        }
    }


}
