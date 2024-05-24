using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string LookingFor { get; set; }
    }
}
