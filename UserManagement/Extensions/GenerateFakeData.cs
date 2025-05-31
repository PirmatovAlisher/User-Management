namespace UserManagement.Extensions
{
	public static class GenerateFakeData
	{
		private static readonly Random _random = new Random();

		public static List<DateTime> GenerateActivityTimestamps(DateTime lastLogin)
		{
			var timestamps = new List<DateTime>();
			int daysBack = 30;

			for (int i = 0; i < 15; i++)
			{
				int daysAgo = _random.Next(0, daysBack);
				int hoursAgo = _random.Next(0, 24);
				int minutesAgo = _random.Next(0, 60);

				timestamps.Add(lastLogin.AddDays(-daysAgo)
					.AddHours(-hoursAgo)
					.AddMinutes(-minutesAgo));
			}

			return timestamps.OrderBy(d => d).ToList();
		}
	}
}
