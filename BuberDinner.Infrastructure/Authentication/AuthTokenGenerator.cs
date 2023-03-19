using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BuberDinner.Application.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Authentication
{
    public class AuthTokenGenerator : IAuthTokenGenerator
    {
        private readonly IOptions<JwtSettings> _jwtSettings;
        public AuthTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.Value.ExpirationInDays));
            var token = new JwtSecurityToken(
                _jwtSettings.Value.Issuer,
                _jwtSettings.Value.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}