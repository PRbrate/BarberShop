using System.Security.Claims;

namespace BarberShop.Core
{
    public static class ClaimsPrincipalExtensions
    {
        public static long GetAccountId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var accountId = principal.Claims.FirstOrDefault().Value;
            return long.Parse(accountId);
        }
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var userId = principal.Claims.FirstOrDefault(c => c.Type == "UserId").Value;

            return userId;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
    }
}
