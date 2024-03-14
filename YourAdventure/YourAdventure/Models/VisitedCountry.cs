using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class VisitedCountry
    {
        public int VisitedCountries { get; set; }
        public int? PersonFid { get; set; }
        public int? CountryFid { get; set; }

        public virtual Country? CountryF { get; set; }
        public virtual Person? PersonF { get; set; }
    }
}
