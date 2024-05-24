using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities
{
    public class Group
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
}
