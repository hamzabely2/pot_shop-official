using Entity.Model;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Service.Interface
{
    public interface IConnectionService
    {
        bool IsValidEmail(string email);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        JwtSecurityToken CreateToken(IEnumerable<Claim> claims);
        bool IsPasswordValid(string password);
        UserInfo GetCurrentUserInfo(IHttpContextAccessor _httpContextAccessor);
    }
}
