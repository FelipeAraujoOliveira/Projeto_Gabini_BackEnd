using Core.Models;
using Core.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Presentation.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:SecretKey"]
                         ?? throw new InvalidOperationException("JwtSettings:SecretKey não está configurada.");
        }

        public string CreateUsuarioToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NomeCompleto),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("id", usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
