using System.Security.Claims;

namespace OnlineEdu.WebUI.Services.TokenServices
{
    public class TokenService(IHttpContextAccessor httpContextAccessor) : ITokenService
    {
        public string GetUserToken => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Token").Value;
        public string GetUserRole => httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
        public int GetUserId => int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public string GetUserNameSurname => httpContextAccessor.HttpContext.User.FindFirst("fullName").Value;
    }
    
    
}
