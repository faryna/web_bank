using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBank.WebUI.Models;
using WebBank.Business.Managers.Interfaces;
using WebBank.Security;
using System.Security.Claims;
using WebBank.Data.Infrastructure.Enums;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBank.WebUI.Controllers
{
    public class UserAccountController : Controller
    {
        public IUserAccountManager UserAccountManager { get; set; }

        public UserAccountController(IUserAccountManager userAccountManager)
        {
            UserAccountManager = userAccountManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await UserAccountManager.GetByEmailAndPassword(model.Email, model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.IsAdmin? Enum.GetName(typeof(UserRole), UserRole.Admin) : Enum.GetName(typeof(UserRole), UserRole.Client))
                };

                var claimsIdentity = new ClaimsIdentity(claims, "password");
                var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.Authentication.SignInAsync("Cookies", claimsPrinciple);

                return Redirect("~/");
            }

            return Redirect("~/UserAccount/Login");


        }
    }
}
