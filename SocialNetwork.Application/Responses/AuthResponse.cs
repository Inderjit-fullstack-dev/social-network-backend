namespace SocialNetwork.Application.Responses
{
    public class AuthResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LookingFor { get; set; }
        public string Token { get; set; }
    }
}
