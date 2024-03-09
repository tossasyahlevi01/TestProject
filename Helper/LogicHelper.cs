using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestProject.DTO;

namespace TestProject.Helper
{
    public class LogicHelper : IHelper
    {

        public async Task<(string Token, bool cek)> GenerateToken2(UserLogonDTO Entity)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("qwertyuiopasdfghjklzxcvbnm123456"); // Replace with your secret key
                var claims = new[]
               {
               
                  new Claim("Username",Entity.Username),
                   new Claim("Password",Entity.Password)

            };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = "Tossa",

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return (tokenString, false);
            }
            catch (Exception ex)
            {
                return (null, true);
            }
        }

    }
}
