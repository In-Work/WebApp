using Microsoft.AspNetCore.Identity;

namespace WebAppDB.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
