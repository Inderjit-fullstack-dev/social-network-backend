namespace SocialNetwork.Infrastructure.Jwt
{
    public interface IJwtService
    {
        string CreateToken(UserData userData);
    }
}
