using ArielProject.DTOs;
using ArielProject.Services;

namespace ArielProject.Interfaces.IServices
{
    public interface IAccountService
    {

        public SignInAndUpResult HandleUserLogin(UserLoginDto userLoginDto);
        public SignInAndUpResult HandleUserRegister(UserRegisterDto userRegisterDto);
    }
}
