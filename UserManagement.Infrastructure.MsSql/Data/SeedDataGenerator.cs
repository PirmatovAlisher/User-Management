using System.Security.Cryptography;
using System.Text;
using UserManagement.Core.Models;

namespace UserManagement.Infrastructure.MsSql.Data
{
	public static class SeedDataGenerator
	{
		public static List<User> GetUsers()
		{
			return new List<User>
		{
			new User {Id = 1, Name = "Admin User", Email = "admin@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = true, RegistrationTime = DateTime.UtcNow.AddYears(-1), LastLoginTime = DateTime.UtcNow },
			new User {Id = 2, Name = "John Smith", Email = "john@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = true, RegistrationTime = DateTime.UtcNow.AddMonths(-6), LastLoginTime = DateTime.UtcNow.AddDays(-1) },
			new User {Id = 3, Name = "Sarah Johnson", Email = "sarah@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = true, RegistrationTime = DateTime.UtcNow.AddMonths(-3), LastLoginTime = DateTime.UtcNow.AddHours(-3) },
			new User {Id = 4, Name = "Mike Brown", Email = "mike@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = false, RegistrationTime = DateTime.UtcNow.AddMonths(-4), LastLoginTime = DateTime.UtcNow.AddDays(-10) },
			new User {Id = 5, Name = "Emily Davis", Email = "emily@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = true, RegistrationTime = DateTime.UtcNow.AddMonths(-2), LastLoginTime = DateTime.UtcNow.AddHours(-5) },
			new User {Id = 6, Name = "Robert Wilson", Email = "robert@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = true, RegistrationTime = DateTime.UtcNow.AddMonths(-5), LastLoginTime = DateTime.UtcNow.AddDays(-2) },
			new User {Id = 7, Name = "Lisa Miller", Email = "lisa@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = false, RegistrationTime = DateTime.UtcNow.AddMonths(-7), LastLoginTime = DateTime.UtcNow.AddDays(-15) },
			new User {Id = 8, Name = "David Taylor", Email = "david@example.com", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", IsActive = true, RegistrationTime = DateTime.UtcNow.AddMonths(-1), LastLoginTime = DateTime.UtcNow.AddHours(-1) }
		};
		}
	}
}
