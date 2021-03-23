using System;
using System.Linq;
using System.Security.Claims;

namespace Extensions.Base
{
    public static class IdentityExtensions
    {
        public static Guid? GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                return Guid.Parse(userId);
            }

            return null;
        }
    }
}