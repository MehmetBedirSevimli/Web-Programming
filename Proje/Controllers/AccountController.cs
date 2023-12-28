using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.Data;
using Proje.Data; // ApplicationUser sınıfının bulunduğu namespace
using Proje.Models.ViewModels; // Gerekirse ViewModel kullanabilirsiniz

/*Register ve Login işlemleri için iki ayrı action metodunu içeren
  bir AccountController sınıfı bulunmaktadır. Bu action metodları, ilgili sayfalara yönlendirme yapar. 
  Register action'ı yeni bir kullanıcı kaydı 
  oluştururken, Login action'ı ise 
  kullanıcı girişi yapmaktadır.

  Register action'ında kullanıcı kaydı oluşturulduktan sonra, SignInManager kullanılarak 
  kullanıcı otomatik olarak giriş yapılır. Login action'ında ise kullanıcı 
  giriş bilgileri doğrulandıktan sonra yönlendirme yapılır.
*/
namespace Proje.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home"); // Başarılı kayıt olduktan sonra yönlendirilecek sayfa
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Başarılı giriş yaptıktan sonra yönlendirilecek sayfa
                }

                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Başarılı çıkış yaptıktan sonra yönlendirilecek sayfa
        }
    }
}
