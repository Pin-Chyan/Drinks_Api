namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly AuditService _auditService;

        public AuditController(AuditService AuditService)
        {
            this._auditService = AuditService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audit>>> GetAllAudits()
        {
            var audits = await _auditService.GetAllAuditsAsync();

            return Ok(audits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Audit>> GetAuditById(long id)
        {
            var audit = await _auditService.GetAuditByIdAsync(id);
            if (audit == null)
            {
                return NotFound();
            }

            return Ok(audit);
        }

        [HttpPost]
        public async Task<ActionResult<Audit>> CreateAudit([FromBody] AuditDto auditDto)
        {
            var createdAudit = await _auditService.CreateAuditAsync(auditDto);
            if (createdAudit == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdAudit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Audit>> UpdateAudit(long id, [FromBody] AuditDto updatedAuditDto)
        {
            var updatedAudit = await _auditService.UpdateAuditAsync(id, updatedAuditDto);
            if (updatedAudit == null)
            {
                return NotFound();
            }

            return Ok(updatedAudit);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAudit(long id)
        {
            var isDeleted = await _auditService.DeleteAuditAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
