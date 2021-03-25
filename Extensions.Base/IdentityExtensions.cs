using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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

        public static string JwtGenerator(IEnumerable<Claim> claims, string key, string issuer, string audience, DateTime expiration)
        {
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signInCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expiration,
                signingCredentials: signInCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}