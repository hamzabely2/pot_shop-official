using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public class GenerateToken
    {

        public class ApiResponse<T>
        {
            public string Message { get; set; }
            public T Result { get; set; }
        }

        public static string GenerateJwtTokenForUser(ClaimsPrincipal user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"); // Changez ceci avec votre clé secrète réelle
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = user.Identity as ClaimsIdentity,
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = "http://localhost:7269",
                Issuer = "http://localhost:8080",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
