using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebProgramlama.Services
{
    public class AuthService: IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentlyLoggedInUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public void Login(string userId)
        {
            // Kullanıcı oturum açtığında çağrılan bir metod
            // Burada HttpContextAccessor kullanmak yerine, Identity'nin sağladığı metotları kullanabilirsiniz.
            // Bu metotlar kullanıcının kimliğini tutarlar.
            // Örnek olarak: _signInManager.SignInAsync(user, isPersistent: false);
        }

        public void Logout()
        {
            // Kullanıcı oturumu kapattığında çağrılan bir metod
            // Burada HttpContextAccessor kullanmak yerine, Identity'nin sağladığı metotları kullanabilirsiniz.
            // Örnek olarak: _signInManager.SignOutAsync();
        }
    }
}
