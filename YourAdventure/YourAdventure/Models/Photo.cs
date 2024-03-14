using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public byte[]? Photo1 { get; set; }
        public int? CountryFid { get; set; }

        public virtual Country? CountryF { get; set; }
    }
}
