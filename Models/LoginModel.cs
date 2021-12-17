using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await
               _userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded) ;
                    {
                        return Redirect(loginModel?.ReturnUrl ??
                       "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
            return View(loginModel);

            public async Task<RedirectResult> Logout(string returnUrl = "/")
            {
                await _signInManager.SignOutAsync();
                return Redirect(returnUrl);
            }
        }
    }
}
