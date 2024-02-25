namespace Saluteo.Services
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class AuditService
    {
        private readonly IGenericRepository<Audit> _auditRepository;

        public AuditService(IGenericRepository<Audit> AuditRepository)
        {
            _auditRepository = AuditRepository;
        }

        public async Task<List<Audit>> GetAllAuditsAsync()
        {
            var audits = await _auditRepository.GetAllAsync();

            return audits.ToList();
        }

        public async Task<Audit?> GetAuditByIdAsync(long id)
        {
            var audit = await _auditRepository.GetByIdAsync(id);
            if (audit == null)
            {
                return null;
            }

            return audit;
        }

        public async Task<Audit?> CreateAuditAsync(AuditDto auditDto)
        {
            if (auditDto == null)
            {
                return null;
            }

            var audit = new Audit
            {
                // Barcode validation
                JsonBefore = auditDto.JsonBefore,
                JsonAfter = auditDto.JsonAfter,
                CompanyId = auditDto.CompanyId,
                UserId = auditDto.UserId,
            };

            await _auditRepository.InsertAsync(audit);
            return audit;
        }

        public async Task<Audit?> UpdateAuditAsync(long id, AuditDto updatedAuditDto)
        {
            var existingAudit = await GetAuditByIdAsync(id);
            if (existingAudit == null)
            {
                return null;
            }

            existingAudit.JsonBefore = updatedAuditDto.JsonBefore;
            existingAudit.JsonAfter = updatedAuditDto.JsonAfter;
            existingAudit.CompanyId = updatedAuditDto.CompanyId;
            existingAudit.UserId = updatedAuditDto.UserId;

            await _auditRepository.UpdateAsync(existingAudit);
            return existingAudit;
        }

        public async Task<bool> DeleteAuditAsync(long id)
        {
            var existingAudit = await _auditRepository.GetByIdAsync(id);
            if (existingAudit == null)
            {
                return false;
            }

            await _auditRepository.DeleteAsync(id);
            return true;
        }
    }
}
