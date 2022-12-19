using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models.Categories;
using TestWebAPI.Models.Users;
using TestWebAPI.Services.Interfaces;
namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public void Add([FromBody] CreateUser createUser)
        {
             _userService.Create(createUser);
        }

        [HttpGet]
        public IEnumerable<CreateUser> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        public void GetById(int id)
        {
             _userService.GetById(id)
;
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] CreateUser updateUser)
        {
             _userService.Update(id, updateUser);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _userService.Delete(id);
        }
    }
}