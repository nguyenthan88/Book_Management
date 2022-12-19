using TestWebAPI.Models.Users;

namespace TestWebAPI.Services.Interfaces
{
    public interface IUserService
    {
        void Create(CreateUser createUser);

        IEnumerable<CreateUser> GetAll();

        LoginResponse Login(LoginRequest loginRequest);

        void GetById(int id);

        CreateUser Update(int id, CreateUser updateUser);

        bool Delete(int id);
    }
}