using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace EcommerceApi.Services
{
    public class CurrentUserService:ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? userId
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

                if (claim == null)
                    return null;

                if (!int.TryParse(claim.Value, out int userID))
                    return null;
                return userId;
            }
        }

        public string? Role
        {
            get
            {
                return _httpContextAccessor.HttpContext?
                    .User
                    .FindFirst(ClaimTypes.Role)?.Value;
            }
        }
    }
}
