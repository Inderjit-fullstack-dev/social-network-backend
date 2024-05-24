using Microsoft.AspNetCore.Identity;
namespace SocialNetwork.Domain.Entities
{
    public class AppUser : IdentityUser<long>
    {
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool HasBadge { get; set; } = false;
        public string RelationshipStatus { get; set; }
        public string CoverUrl { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
