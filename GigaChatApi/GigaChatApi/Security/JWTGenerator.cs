using GigaChatApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GigaChatApi.Security
{
    public class JWTGenerator
    {
        private readonly SymmetricSecurityKey _key;

        public JWTGenerator()
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("GIGACHAT_TOKEN_KEY")!));
        }

        public string GenerateToken(AppUser user) 
        {
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, user.Id) };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
