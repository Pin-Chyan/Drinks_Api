namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class UserBranchAccessController : ControllerBase
    {
        private readonly IGenericRepository<UserBranchAccess> _userBranchAccessRepository;

        public UserBranchAccessController(IGenericRepository<UserBranchAccess> userBranchAccessRepository)
        {
            _userBranchAccessRepository = userBranchAccessRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserBranchAccess>> GetAllCompanies()
        {
            var userBranchAccesses = _userBranchAccessRepository.GetAllAsync();
            return Ok(userBranchAccesses);
        }

        [HttpPost]
        public ActionResult CreateuserBranchAccess([FromBody] UserBranchAccessDto userBranchAccessDto)
        {
            if (userBranchAccessDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var userBranchAccess = new UserBranchAccess
            {
                UserBranchAccessId = userBranchAccessDto.UserBranchAccessId,
                UserId = userBranchAccessDto.UserId,
                BranchId = userBranchAccessDto.BranchId,
                SecurityAccessCodeId = userBranchAccessDto.SecurityAccessCodeId
            };

            _userBranchAccessRepository.InsertAsync(userBranchAccess);

            return Ok(userBranchAccess);
        }
    }
}
