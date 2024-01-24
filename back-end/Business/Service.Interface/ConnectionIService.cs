using Entity.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Service.Interface
{
    public interface ConnectionIService
    {
        bool IsValidEmail(string email);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        JwtSecurityToken CreateToken(IEnumerable<Claim> claims);
        bool IsPasswordValid(string password);
        UserInfo GetCurrentUserInfo();
    }
}
