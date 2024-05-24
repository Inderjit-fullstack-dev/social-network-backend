namespace SocialNetwork.Infrastructure.Jwt
{
    public class UserData
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }

        public UserData()
        {
            Roles = [];
        }
    }
}