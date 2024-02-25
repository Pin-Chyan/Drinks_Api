using Saluteo.Models.Entity;
using Saluteo.Repository;

namespace Saluteo.Services
{
    public class UserBranchAccessService
    {
        private readonly IGenericRepository<UserBranchAccess> _userBranchAccessRepository;

        public UserBranchAccessService(IGenericRepository<UserBranchAccess> UserBranchAccessRepository)
        {
            _userBranchAccessRepository = UserBranchAccessRepository;
        }

        public async Task<List<UserBranchAccess>> GetAllUserBranchAccesssAsync()
        {
            var userBranchAccesss = await _userBranchAccessRepository.GetAllAsync();

            return userBranchAccesss.ToList();
        }

        public async Task<UserBranchAccess?> GetUserBranchAccessByIdAsync(long id)
        {
            var userBranchAccess = await _userBranchAccessRepository.GetByIdAsync(id);
            if (userBranchAccess == null)
            {
                return null;
            }

            return userBranchAccess;
        }

        public async Task<UserBranchAccess?> CreateUserBranchAccessAsync(UserBranchAccessDto userBranchAccessDto)
        {
            if (userBranchAccessDto == null)
            {
                return null;
            }

            var UserBranchAccess = new UserBranchAccess
            {
                // Barcode validation
                UserBranchAccessId = userBranchAccessDto.UserBranchAccessId,
                UserId = userBranchAccessDto.UserId,
                BranchId = userBranchAccessDto.BranchId,
                SecurityAccessCodeId = userBranchAccessDto.SecurityAccessCodeId,
            };

            await _userBranchAccessRepository.InsertAsync(UserBranchAccess);
            return UserBranchAccess;
        }

        public async Task<UserBranchAccess?> UpdateUserBranchAccessAsync(long id, UserBranchAccessDto updatedUserBranchAccessDto)
        {
            var existingUserBranchAccess = await GetUserBranchAccessByIdAsync(id);
            if (existingUserBranchAccess == null)
            {
                return null;
            }

            existingUserBranchAccess.UserBranchAccessId = updatedUserBranchAccessDto.UserBranchAccessId;
            existingUserBranchAccess.UserId = updatedUserBranchAccessDto.UserId;
            existingUserBranchAccess.BranchId = updatedUserBranchAccessDto.BranchId;
            existingUserBranchAccess.SecurityAccessCodeId = updatedUserBranchAccessDto.SecurityAccessCodeId;

            await _userBranchAccessRepository.UpdateAsync(existingUserBranchAccess);
            return existingUserBranchAccess;
        }

        public async Task<bool> DeleteUserBranchAccessAsync(long id)
        {
            var existingUserBranchAccess = await _userBranchAccessRepository.GetByIdAsync(id);
            if (existingUserBranchAccess == null)
            {
                return false;
            }

            await _userBranchAccessRepository.DeleteAsync(id);
            return true;
        }
    }
}
