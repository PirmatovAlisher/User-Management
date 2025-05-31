using Microsoft.EntityFrameworkCore;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Models;
using UserManagement.Infrastructure.MsSql.Data;

namespace UserManagement.Infrastructure.MsSql.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UserDbContext _context;

		public UserRepository(UserDbContext context)
		{
			_context = context;
		}

		public async Task AddUserAsync(User user)
		{
			await _context.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		public async Task BlockUsers(List<int> ids)
		{
			var users = await GetUsersByIdAsync(ids);

			foreach (var user in users)
			{
				user.IsActive = false;
				_context.Update(user);
			}

			await _context.SaveChangesAsync();
		}

		public async Task DeleteUsersAsync(List<int> ids)
		{
			var users = await GetUsersByIdAsync(ids);

			_context.RemoveRange(users);
			await _context.SaveChangesAsync();
		}

		public IQueryable<User> GetAllUsers()
		{
			return _context.Users.AsQueryable();
		}

		public async Task UnBlockUsers(List<int> ids)
		{
			var users = await GetUsersByIdAsync(ids);

			foreach (var user in users)
			{
				user.IsActive = true;
				_context.Update(user);
			}

			await _context.SaveChangesAsync();
		}

		public async Task<List<User>> GetUsersByIdAsync(List<int> ids)
		{
			var users = new List<User>();

			foreach (var id in ids)
			{
				var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

				if (user != null)
				{
					users.Add(user);
				}
			}

			return users;
		}
	}
}
