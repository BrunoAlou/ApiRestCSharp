using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SeniorApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace SeniorApi.Services
{
  public static class TokenService
  {
    public static string GenerateToken(User user)
    {
      var handler = new JwtSecurityTokenHandler();
      var secretKeyBytes = Encoding.ASCII.GetBytes(Settings.Secret);

      var descriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
          {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
      };

      var generatedToken = handler.CreateToken(descriptor);
      return handler.WriteToken(generatedToken);
    }
  }
}
