namespace TestWebAPI.Models.Users
{
    public class LoginResponse
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Token { get; set; }
    }
}