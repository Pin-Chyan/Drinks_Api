namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly BranchService _branchService;

        public BranchController(BranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAllBranch()
        {
            var branches = await _branchService.GetAllBranchesAsync();

            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranchById(long id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> CreateBranch([FromBody] BranchDto branchDto)
        {
            var createdBranch = await _branchService.CreateBranchAsync(branchDto);

            if (createdBranch == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdBranch);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Branch>> UpdateBranch(long id, [FromBody] BranchDto updatedBranchDto)
        {
            var updatedBranch = await _branchService.UpdateBranchAsync(id, updatedBranchDto);

            if (updatedBranch == null)
            {
                return NotFound();
            }

            return Ok(updatedBranch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBranch(long id)
        {
            var isDeleted = await _branchService.DeleteBranchAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
