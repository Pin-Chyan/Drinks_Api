namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IRepository<Audit> _auditRepository;

        public AuditController(IRepository<Audit> auditRepository)
        {
            _auditRepository = auditRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Audit>> GetAllAudits()
        {
            var audits = _auditRepository.GetAll().ToList();
            return Ok(audits);
        }
    }
}
