using GameTime.Services;
using Microsoft.AspNetCore.Mvc;
using GameTime.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace GameTime.Controllers
{
    public class UserController : Controller
    {
        private readonly UserServices _userServices;
        public UserController (UserServices userServices) 
        { 
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationVM user)
        {
            if (ModelState.IsValid)
            {
                if (await _userServices.EmailExistsInRegistration(user.Email))
                {
                    ModelState.AddModelError("Email", ".البريد الالكتروني مستخدم من قبل");
                    return View(user);
                }

                if (await _userServices.UserNameExistsInRegistration(user.UserName))
                {
                    ModelState.AddModelError("UserName", ".اسم المستخدم مستخدم من قبل");
                    return View(user);
                }

                await _userServices.AddUser(user);
                return RedirectToAction("Login", "User");
            }
            return View(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var user = HttpContext.User;

            if (user?.Identity?.IsAuthenticated == true)
            {
                var role = user.FindFirst(ClaimTypes.Role)?.Value;

                if (role == "User") 
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM userlogin)
        {
            if (ModelState.IsValid)
            {
                var user = await _userServices.AuthenticateUser(userlogin.UserName, userlogin.Password);

                if (user == null)
                {
                    ViewData["ErrorMessage"] = "اسم المستخدم او كلمة المرور غير صحيحة";
                    return View(userlogin);
                }

                // Create Claims after user is authenticated and able to login
                var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.role.ToString())
                };

                var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties { IsPersistent = userlogin.RememberMe });

                return RedirectToAction("Index", "Home");
            }

            return View(userlogin);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

    }
}
