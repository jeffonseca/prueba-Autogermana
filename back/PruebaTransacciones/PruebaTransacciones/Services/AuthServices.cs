using Microsoft.IdentityModel.Tokens;
using PruebaTransacciones.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTransacciones.Services
{
    public class AuthServices : IAuthServices
    {
        public string getUserAndPasword(string user, string password)
        {
            var isValidateCredencial = validateCredencial(user, password);
            if (isValidateCredencial)
            {
                var token = GenerateJwtToken(user);
                return token.ToString();
            }
            return null;
        }

        public bool validateCredencial(string user, string password) {

            if (user == "prueba" && password == "prueba123") { 
                return true;
            }
            return false;
        }
        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKeyWithAtLeast128BitsLength"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: new[] {
                new Claim(ClaimTypes.Name, username),
                    // Puedes agregar más claims según necesites
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
