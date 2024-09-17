using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.ViewModels.UserInfoViewModels;

namespace TechnologyKeeda.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserInfoViewModel vm)
        {
            var user= await _userRepo.GetUserInfo(vm.UserName,vm.Password);
            this.HttpContext.Session.SetInt32("userId", user.UserId);
            this.HttpContext.Session.SetString("userName", user.UserName);
            return RedirectToAction("Index", "Countries");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfoViewModel vm)
        {
            var model = new UserInfo()
            { 
                UserName = vm.UserName,
                Password = vm.Password 
            };

            await _userRepo.RegisterUser(model);

            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
