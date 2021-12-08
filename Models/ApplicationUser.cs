using Microsoft.AspNetCore.Identity;

namespace GameHeaven.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfilePicturePath { get; set; }
        public string CoverPath { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
    }
}
