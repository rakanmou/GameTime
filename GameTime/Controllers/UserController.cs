using GameTime.Services;
using GameTime.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Register(UserRegistrationVM user)
        {
            if (ModelState.IsValid)
            {
                await _userServices.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
