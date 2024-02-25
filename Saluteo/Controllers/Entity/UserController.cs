namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService UserService)
        {
            this._userService = UserService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(long id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserDto userDto)
        {
            var createdUser = await _userService.CreateUserAsync(userDto);
            if (createdUser == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(long id, [FromBody] UserDto updatedUserDto)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, updatedUserDto);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            var isDeleted = await _userService.DeleteUserAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
