using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class Color
    {
        public Color()
        {
            Settings = new HashSet<Setting>();
        }

        public int ColorId { get; set; }
        public string? ColorName { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
