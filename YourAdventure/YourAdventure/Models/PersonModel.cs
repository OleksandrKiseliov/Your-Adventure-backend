using System.ComponentModel.DataAnnotations;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Models
{
    public class PersonModel
    {
        public Guid PersonId { get; set; }

        public string Nickname { get; set; }

        public DateTime? Birthday { get; set; }

        public string Email { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        public string Password { get; set; }

        public Guid SettingsId { get; set; }
    }
}
