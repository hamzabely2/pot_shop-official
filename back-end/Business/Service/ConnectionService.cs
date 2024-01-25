using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Service.Interface;
using Entity.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;

namespace Service
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConfiguration _configuration;

        public ConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        /// <summary>
        /// checked email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// hash password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        /// <summary>
        /// verify password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        /// <summary>
        /// create token
        /// </summary>
        /// <param name="authClaims"></param>
        /// <returns></returns>
        public JwtSecurityToken CreateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return token;
        }

        /// <summary>
        /// checked password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsPasswordValid(string password)
        {
            var regex = new Regex(@"^(?=.*[A-Z]).{8,}$");

            return regex.IsMatch(password);
        }


        /// <summary>
        /// get info user
        /// </summary>
        /// <returns></returns>
        public UserInfo GetCurrentUserInfo(IHttpContextAccessor _httpContextAccessor)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

            return new UserInfo()
            {
                Id = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value),
                UserName = principal.FindFirst(ClaimTypes.Name)?.Value,
                Email = principal.FindFirst(ClaimTypes.Email)?.Value,
                Role = principal.FindFirst(ClaimTypes.Role)?.Value,
            };
        }
    }
}
