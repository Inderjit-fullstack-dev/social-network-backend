using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities
{
    public class Photo
    {
        [Key]
        public long Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public long AppUserId { get; set; }

        // Navigation Property
        public AppUser AppUser { get; set; }
    }
}
