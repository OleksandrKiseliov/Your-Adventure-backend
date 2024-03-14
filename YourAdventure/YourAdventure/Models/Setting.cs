using System;
using System.Collections.Generic;

namespace YourAdventure.Models
{
    public partial class Setting
    {
        public int SettingsId { get; set; }
        public int? InterfaceLanguageFid { get; set; }
        public bool? Notification { get; set; }
        public int? ColorFid { get; set; }
        public int? PersonFid { get; set; }

        public virtual Color? ColorF { get; set; }
        public virtual InterfaceLanguage? InterfaceLanguageF { get; set; }
        public virtual Person? PersonF { get; set; }
    }
}
