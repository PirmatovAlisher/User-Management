using UserManagement.Core.Models;

namespace UserManagement.Core.Interfaces
{
	public interface IUserRepository
	{
		Task AddUserAsync(User user);
		IQueryable<User> GetAllUsers();
		Task<List<User>> GetUsersByIdAsync(List<int> ids);
		Task DeleteUsersAsync(List<int> ids);
		Task BlockUsers(List<int> ids);
		Task UnBlockUsers(List<int> ids);
	}
}
