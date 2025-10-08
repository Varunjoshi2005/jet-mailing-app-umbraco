using ArielProject.DTOs;
using ArielProject.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using Umbraco.Cms.Core.Persistence.Repositories;

namespace ArielProject.Services
{
    public class SignInAndUpResult
    {
        public required string Message;
        public required bool Status;
        public required string data;
    }

    

    public class AccountService(IUserRepository userRepository, PasswordHasher<string> passwordHasher) : IAccountService
    {

        private readonly string _jwtSecret = "6\x15ÿ\x83Jf\x97¬Ô\x80âÌo\x12R}\x9EëãñìGx±¢\x9D\x95/$D\x82J4\x95\b\x0BJ\b\x07Æ";
        private readonly int _jwtLifeSpanMinutes = 60;
        private readonly IUserRepository _userRespository = userRepository;
        private readonly PasswordHasher<string> _passwordHasher = passwordHasher;

        public SignInAndUpResult HandleUserLogin(UserLoginDto userLoginDto)
        {
            return new SignInAndUpResult
            {
                Message = "Something",
                data = "any",
                Status = true
            };

        }

        public SignInAndUpResult HandleUserRegister(UserRegisterDto userRegisterDto)
        {
              

            return new SignInAndUpResult
            {
                Message = "Something",
                data = "any",
                Status = true
            };

        }
    }
}
