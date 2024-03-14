using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class AchievementStatus
    {
        public AchievementStatus()
        {
            Achievements = new HashSet<Achievement>();
        }

        public int AchievementStatusId { get; set; }
        public string? AchievementStatusName { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
