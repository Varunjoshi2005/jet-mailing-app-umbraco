using ArielProject.DTOs;
using ArielProject.Services;

namespace ArielProject.Interfaces.IServices
{
    public interface IAccountService
    {

        public SignInAndUpResult HandleUserLoginAsync(UserLoginDto userLoginDto);
        public SignInAndUpResult HandleUserRegister(UserRegisterDto userRegisterDto);

        private string GenerateToken(UserTokenDto userTokenDto);
    }
}
