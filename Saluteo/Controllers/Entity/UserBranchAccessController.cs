namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;
    using Saluteo.Services;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class UserBranchAccessController : ControllerBase
    {
        private readonly UserBranchAccessService _userBranchAccessService;

        public UserBranchAccessController(UserBranchAccessService UserBranchAccessService)
        {
            this._userBranchAccessService = UserBranchAccessService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBranchAccess>>> GetAllUserBranchAccesss()
        {
            var userBranchAccesss = await _userBranchAccessService.GetAllUserBranchAccesssAsync();

            return Ok(userBranchAccesss);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserBranchAccess>> GetUserBranchAccessById(long id)
        {
            var userBranchAccess = await _userBranchAccessService.GetUserBranchAccessByIdAsync(id);
            if (userBranchAccess == null)
            {
                return NotFound();
            }

            return Ok(userBranchAccess);
        }

        [HttpPost]
        public async Task<ActionResult<UserBranchAccess>> CreateUserBranchAccess([FromBody] UserBranchAccessDto userBranchAccessDto)
        {
            var createdUserBranchAccess = await _userBranchAccessService.CreateUserBranchAccessAsync(userBranchAccessDto);
            if (createdUserBranchAccess == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdUserBranchAccess);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserBranchAccess>> UpdateUserBranchAccess(long id, [FromBody] UserBranchAccessDto updatedUserBranchAccessDto)
        {
            var updatedUserBranchAccess = await _userBranchAccessService.UpdateUserBranchAccessAsync(id, updatedUserBranchAccessDto);
            if (updatedUserBranchAccess == null)
            {
                return NotFound();
            }

            return Ok(updatedUserBranchAccess);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserBranchAccess(long id)
        {
            var isDeleted = await _userBranchAccessService.DeleteUserBranchAccessAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
