using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities
{
    public class Connection
    {
        [Key]
        public long Id { get; set; }
        public string ConnectionId { get; set; }
        public string Username { get; set; }
    }
}
