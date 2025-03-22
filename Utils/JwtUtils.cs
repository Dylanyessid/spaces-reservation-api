using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SpacesReservation.API.Models;
namespace SpacesReservation.API.Utils
{
    public static class JwtUtils
    {
        public static string GenerateJWT(User user)
        {

            //Data in the JWT 
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user!.Id!.ToString()),
                new Claim(ClaimTypes.Email, user!.Email!),
                
            };

            //Generate creds for the JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hH*b19P506p1T?be(l]bVR1++;&y}£UGDix)JV[M#p+7v"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    
    }
}
