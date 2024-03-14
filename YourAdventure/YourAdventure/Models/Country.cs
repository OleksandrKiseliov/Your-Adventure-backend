using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class Country
    {
        public Country()
        {
            Photos = new HashSet<Photo>();
            VisitedCountries = new HashSet<VisitedCountry>();
        }

        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<VisitedCountry> VisitedCountries { get; set; }
    }
}
