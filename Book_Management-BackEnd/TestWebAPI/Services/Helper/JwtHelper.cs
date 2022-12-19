using Common.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestWebAPI.Models.Users;

namespace TestWebAPI.Services.Helper
{
    public class JWTHelper
    {
        public static string CreateJwtToken(UserModel userModel)
        {

            var claims = new Claim[]
                 {
                    new Claim(ClaimTypes.Role,userModel.Role.ToString()),
                    new Claim("Id", userModel.Id.ToString())
                 };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstant.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expired = DateTime.UtcNow.AddDays(JwtConstant.ExpiredTime);

            var token = new JwtSecurityToken(JwtConstant.Issuer, JwtConstant.Audience,
                claims, expires: expired, signingCredentials: signIn);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}