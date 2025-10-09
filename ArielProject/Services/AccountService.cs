using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArielProject.DTOs;
using ArielProject.Interfaces.IServices;
using ArielProject.Models;
using ArielProject.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Umbraco.Cms.Core.Persistence.Repositories;

namespace ArielProject.Services
{
    public class SignInAndUpResult
    {
        public required string Message;
        public required bool Status;
        public required string data;
    }


    public class UserTokenDto
    {
        public Guid UserId;
        public string Username;
        public string Email;
    }



    public class AccountService(UserRepository userRepository, PasswordHasher<string> passwordHasher) : IAccountService
    {

        private readonly string _jwtSecret = "6\x15ÿ\x83Jf\x97¬Ô\x80âÌo\x12R}\x9EëãñìGx±¢\x9D\x95/$D\x82J4\x95\b\x0BJ\b\x07Æ";
        private readonly int _jwtLifeSpanMinutes = 60;
        private readonly UserRepository _userRespository = userRepository;
        private readonly PasswordHasher<string> _passwordHasher = passwordHasher;


        public async Task<SignInAndUpResult> HandleUserLoginAsync(UserLoginDto userLoginDto)
        {
            var user = await _userRespository.GetUserByItsEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                return new SignInAndUpResult { data = null, Status = false, Message = "User doesn't exist with this email." };
            }

            var result = _passwordHasher.VerifyHashedPassword(null, user.Password, userLoginDto.Password);
            if (result != PasswordVerificationResult.Success)
            {
                return new SignInAndUpResult { Status = false, Message = "Invalid password.", data = null };
            }


            UserTokenDto userTokenDto = new UserTokenDto { UserId = user.Id, Username = user.Username, Email = user.Email };
            var token = GenerateToken(userTokenDto);


            return new SignInAndUpResult
            {
                Message = "Something",
                data = token,
                Status = true
            };

        }

        public SignInAndUpResult HandleUserRegister(UserRegisterDto userRegisterDto)
        {

            string Hashpassword = _passwordHasher.HashPassword(null, userRegisterDto.Password);

            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = userRegisterDto.Email,
                Username = userRegisterDto.Username,
                Password = Hashpassword,
                CreatedAt = DateTime.UtcNow,

            };

            _userRespository.HandleAddNewUser(user);

            return new SignInAndUpResult
            {
                Message = "Something",
                data = "any",
                Status = true
            };

        }

        private string GenerateToken(UserTokenDto userTokenDto)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, userTokenDto.UserId.ToString()),
                    new Claim(ClaimTypes.Email, userTokenDto.Email)
                }),

                Expires = DateTime.UtcNow.AddMinutes(_jwtLifeSpanMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}
