using Common.Enums;

namespace TestWebAPI.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        public UserRoleEnum Role { get; set; }
    }
}