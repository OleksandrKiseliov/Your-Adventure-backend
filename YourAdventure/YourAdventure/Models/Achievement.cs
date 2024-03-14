using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class Achievement
    {
        public int AchievementId { get; set; }
        public string? AchievementName { get; set; }
        public int? StatusFid { get; set; }
        public int? PersonFid { get; set; }

        public virtual Person? PersonF { get; set; }
        public virtual AchievementStatus? StatusF { get; set; }
    }
}
