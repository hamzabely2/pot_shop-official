using Microsoft.AspNetCore.Http;
using Repository.Interface.User;
using Service.Interface.User;
using System;
using System.Threading.Tasks;

namespace Service.User
{
    public class MiddlewareUser
    {
        private readonly RequestDelegate _next;
        private readonly UserIRepository _userRepository;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MiddlewareUser(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context, UserIRepository _userRepository, IConnectionService _connectionService, IHttpContextAccessor _httpContextAccessor)
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader != null)
            {
                var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);

                int userConnectedId = userInfo.Id;
                var user = await _userRepository.GetByKeys(userConnectedId);

                if(user != null) { 
                if (user.Deactivated == true )
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Votre compte est actuellement désactivé ou indisponible pour le moment. Pour plus d'informations, contactez le service client.");
                    return;
                    }
                }
            }
            await _next(context);
        }
    }
}