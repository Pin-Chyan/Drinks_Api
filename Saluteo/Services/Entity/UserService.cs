using Saluteo.Models.Entity;
using Saluteo.Repository;

namespace Saluteo.Services
{
    public class UserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> UserRepository)
        {
            _userRepository = UserRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.ToList();
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User?> CreateUserAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            var User = new User
            {
                // Barcode validation
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
            };

            await _userRepository.InsertAsync(User);
            return User;
        }

        public async Task<User?> UpdateUserAsync(long id, UserDto updatedUserDto)
        {
            var existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = updatedUserDto.FirstName,
            existingUser.LastName = updatedUserDto.LastName,
            existingUser.Email = updatedUserDto.Email,
            existingUser.Password = updatedUserDto.Password,

            await _userRepository.UpdateAsync(existingUser);
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return false;
            }

            await _userRepository.DeleteAsync(id);
            return true;
        }
    }
}
