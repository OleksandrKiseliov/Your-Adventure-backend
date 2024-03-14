using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class InterfaceLanguage
    {
        public InterfaceLanguage()
        {
            Settings = new HashSet<Setting>();
        }

        public int InterfaceLanguageId { get; set; }
        public string? InterfaceLanguage1 { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
