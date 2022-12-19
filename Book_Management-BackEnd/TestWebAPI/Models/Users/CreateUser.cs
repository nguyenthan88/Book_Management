using Common.Enums;

namespace TestWebAPI.Models.Users
{
    public class CreateUser
    {   
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
         
        public UserRoleEnum Role { get; set; }
    }
}
