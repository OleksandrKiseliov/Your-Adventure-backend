using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class Person
    {
        public Person()
        {
            Achievements = new HashSet<Achievement>();
            Settings = new HashSet<Setting>();
            VisitedCountries = new HashSet<VisitedCountry>();
        }

        public int PersonId { get; set; }
        public string? Nickname { get; set; }
        public DateTime? Bday { get; set; }
        public string? Email { get; set; }
        public byte[]? Profilepicture { get; set; }
        public string? Password { get; set; }
        public int? SettingsId { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<VisitedCountry> VisitedCountries { get; set; }
    }
}
