using ArielProject.DTOs;
using ArielProject.Interfaces.IServices;
using ArielProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArielProject.Controllers
{
    public class AccountController(IAccountService accountService) : Controller
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost]
        public IActionResult Login(UserLoginDto userLogin)
        {
            try
            {
                SignInAndUpResult result = _accountService.HandleUserLogin(userLogin);
                if (!result.Status)
                {
                    throw new Exception(result.Message);
                }

                return new JsonResult(new { message = "Logged in successfully!", data = result.data });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto userRegister)
        {
            try
            {
                SignInAndUpResult result = _accountService.HandleUserRegister(userRegister);
                if (!result.Status)
                {
                    throw new Exception(result.Message);
                }
                return new JsonResult(new { message = "Registered successfully!!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;

            }
        }

    }
}
