using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Models;

namespace UserManagement.Infrastructure.MsSql.Data
{
	public class UserDbContext : DbContext
	{
		public UserDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().
				HasIndex(u => u.Email).
				IsUnique();

			modelBuilder.Entity<User>().HasData(SeedDataGenerator.GetUsers());
		}

	}
}
