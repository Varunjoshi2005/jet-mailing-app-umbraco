using Newtonsoft.Json;

namespace ArielProject.DTOs
{
    public class UserRegisterDto
    {
        [JsonProperty("username")]
        public required string Username;

        [JsonProperty("email")]
        public required string Email;

        [JsonProperty("password")]
        public required string Password;

    };

    public class UserLoginDto
    {


        [JsonProperty("email")]
        public required string Email;

        [JsonProperty("password")]
        public required string Password;

    }
}
