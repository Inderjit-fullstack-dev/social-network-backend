using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Domain.Entities
{
    public class AppRole:IdentityRole<long>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
