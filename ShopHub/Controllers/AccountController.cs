using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.BAL.ModelVM;
using Shop.DAL.Models;

namespace ShopHub.MVC.Controllers
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


        //Register
        //login
        //logout

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                //mapp
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registerVM.UserName,
                    FullName = registerVM.FullName,
                    Email = registerVM.Email,
                    PasswordHash = registerVM.Password,
                    City = registerVM.City,
                    Address = registerVM.Address,

                };

                //save to Db
                //IdentityResult result = await _userManager.CreateAsync(user); //=> noPassword
                IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    //cookie => by Signin Manager
                    await _signInManager.SignInAsync(user, isPersistent: false); //=> Sesion cookie 
                    return RedirectToAction("Index", "Home");
                }


                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }



            }
            return View(registerVM);
        }

        //signOut => Destroy cookie

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }

        //RedirectToLogin

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                //Check Name
                ApplicationUser AppUser = await _userManager.FindByNameAsync(loginVM.UserName);

                if (AppUser != null)
                {
                    //checkPass

                    var Found = await _userManager.CheckPasswordAsync(AppUser, loginVM.Password);
                    if (Found)
                    {
                        //Cookie
                        await _signInManager.SignInAsync(AppUser, loginVM.RememberMe);
                        //Auth
                        return RedirectToAction("Index", "Home");
                    }


                }
                ModelState.AddModelError("", "UserName or Password is UnCorrect !!");



            }

            return View(loginVM);
        }


    }
}
