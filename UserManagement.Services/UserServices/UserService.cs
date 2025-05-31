using UserManagement.Core.Interfaces;
using UserManagement.Core.Models;

namespace UserManagement.Services.UserServices
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<List<User>> GetAllUsersAsync()
		{
			var users = _userRepository.GetAllUsers().OrderByDescending(u => u.LastLoginTime).ToList();

			return users;
		}

		public async Task BlockUsersAsync(List<int> ids)
		{
			await _userRepository.BlockUsers(ids);
		}

		public async Task DeleteUsersAsync(List<int> ids)
		{
			await _userRepository.DeleteUsersAsync(ids);
		}

		public async Task UnBlockUsersAsync(List<int> ids)
		{
			await _userRepository.UnBlockUsers(ids);
		}
	}
}
