namespace SocialNetwork.Infrastructure.Helpers
{
    public static class Utility
    {
        private static readonly Dictionary<string, string> _constants = new()
        {
            // exception messages
            {"InCorrectEmailOrPassword", "Email or password is incorrect."},
            {"UsernameTaken", "Username is already taken."},
            {"EmailTaken", "Email is already taken."},



            // constants
            {"User", "User"},
            {"Admin", "Admin"},
        };


        public static string GetValue(string key)
        {
            return _constants.TryGetValue(key, value: out string value) ? value : string.Empty;
        }
    }
}
