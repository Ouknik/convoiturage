namespace Client.Models
{
    public class AuthResponseDto
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string token { get; set; }
    }

    public class LoginRequestDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class RegisterRequestDto
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}
