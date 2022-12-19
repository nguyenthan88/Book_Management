using Test.Data.Entities;
using TestWebAPI.Models.Users;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Helper;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(CreateUser createUser)
        {
            using (var transaction = _userRepository.DatabaseTransaction())
            {
                try
                {
                    var createUserRequest = new User
                    {                       
                        UserName = createUser.UserName,
                        Password = createUser.Password,
                        FirstName = createUser.FirstName,
                        LastName = createUser.LastName,                      
                    };

                    _userRepository.Create(createUserRequest);
                    _userRepository.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    transaction.RollBack();
                }
            }
        }

        public bool Delete(int id)
        {
            using (var transaction = _userRepository.DatabaseTransaction())
            {
                try
                {
                    var deleteCategory = _userRepository.Get(c => c.UserId == id);

                    if (deleteCategory != null)
                    {
                        bool result = _userRepository.Delete(deleteCategory);

                        _userRepository.SaveChanges();

                        transaction.Commit();

                        return result;
                    }

                    return false;
                }
                catch
                {
                    transaction.RollBack();

                    return false;
                }
            }
        }

        public IEnumerable<CreateUser> GetAll()
        {
            var listUser = _userRepository.GetAll(c => true).Select(user => new CreateUser
            {
                UserId =(int)user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                FirstName= user.FirstName,
                LastName = user.LastName,          
            });

            return listUser;
        }

        public void GetById(int id)
        {
            var requestUser = _userRepository.Get(p => p.UserId == id);

            if (requestUser != null)
            {
                 new CreateUser
                {
                    UserId = (int)requestUser.UserId,
                    UserName =requestUser.UserName,
                    Password =requestUser.Password,
                    FirstName = requestUser.FirstName,
                   LastName =requestUser.LastName,                    
                };
            }
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            var user = _userRepository.Get(user => user.UserName == loginRequest.UserName && user.Password == loginRequest.Password);

            var token = JWTHelper.CreateJwtToken(new UserModel() 
            {
                Id = user.UserId, 
                Role = user.Role           
            });

            return new LoginResponse() { 
                Id = user.UserId,
                UserName= user.UserName, 
                Token= token
            };
        }

        public CreateUser Update(int id, CreateUser updateUser)
        {
            using (var transaction = _userRepository.DatabaseTransaction())
            {
                try
                {
                    var user = _userRepository.Get(c => c.UserId == id);

                    if (user != null)
                    {
                        user.UserName = updateUser.UserName;
                        user.Password = updateUser.Password;
                        user.FirstName = updateUser.FirstName;
                        user.LastName = updateUser.LastName;                      

                      var updatedUser= _userRepository.Update(user);
                        _userRepository.SaveChanges();

                        transaction.Commit();

                        return new CreateUser
                        {
                            UserId = (int)updatedUser.UserId,
                            UserName=updatedUser.UserName,
                            Password=updatedUser.Password,
                            FirstName=updatedUser.FirstName,
                            LastName=updatedUser.LastName,                           
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }
    }
}