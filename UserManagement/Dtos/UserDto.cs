using System.ComponentModel.DataAnnotations;

namespace UserManagement.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsActive { get; set; }
        public List<DateTime> ActivityTimestamps { get; set; } = new List<DateTime>();

        // Computed properties for display
        public string LastLoginLocal => LastLoginTime.ToLocalTime().ToString("g");
        public string RegistrationLocal => RegistrationTime.ToLocalTime().ToString("g");
        public string Status => IsActive ? "Active" : "Blocked";

        // Activity data for chart
        public List<ActivityDay> ActivityData => GetActivityData();

        private List<ActivityDay> GetActivityData()
        {
            var activityData = new List<ActivityDay>();
            var now = DateTime.UtcNow;

            // Create data for last 7 days
            for (int i = 6; i >= 0; i--)
            {
                var date = now.AddDays(-i).Date;
                var activityCount = ActivityTimestamps
                    .Count(t => t.Date == date);

                activityData.Add(new ActivityDay
                {
                    Date = date,
                    Count = activityCount
                });
            }

            return activityData;
        }
    }

    public class ActivityDay
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public string Day => Date.ToString("ddd");
    }
}
