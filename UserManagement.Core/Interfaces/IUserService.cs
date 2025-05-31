using UserManagement.Core.Models;

namespace UserManagement.Core.Interfaces
{
	public interface IUserService
	{
		Task<List<User>> GetAllUsersAsync();
		Task BlockUsersAsync(List<int> ids);
		Task UnBlockUsersAsync(List<int> ids);
		Task DeleteUsersAsync(List<int> ids);
	}
}
