namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserController(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public ActionResult Createuser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            };

            _userRepository.InsertAsync(user);

            return Ok(user);
        }
    }
}
