namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IRepository<Branch> _branchRepository;

        public BranchController(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Branch>> GetAllBranch()
        {
            // questionable
            var branches = _branchRepository.GetAll()
                .Include(_ => _.Company)
                    .ThenInclude(_ => _.CompanyCategory)
                .Include(_ => _.Location)
                    .ThenInclude(_ => _.Region)
                        .ThenInclude(_ => _.Country)
                .ToList();

            return Ok(branches);
        }

        [HttpGet("{id}")]
        public ActionResult<Branch> GetBranchById(long id)
        {
            var branch = _branchRepository.GetById(id);

            if (branch == null)
            {
                return NotFound();
            }

            _branchRepository.LoadNavigationProperties(
                b => b.Company,
                b => b.Company.CompanyCategory,
                b => b.Location,
                b => b.Location.Region,
                b => b.Location.Region.Country
            );

            return Ok(branch);
        }

        [HttpPost]
        public ActionResult CreateBranch([FromBody] BranchDto branchDto)
        {
            if (branchDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var branch = new Branch
            {
                BranchName = branchDto.BranchName,
                CompanyId = branchDto.CompanyId,
                LocationId = branchDto.LocationId,
            };

            _branchRepository.Insert(branch);

            return Ok(branch);
        }
    }
}
