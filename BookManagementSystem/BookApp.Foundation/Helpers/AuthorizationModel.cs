namespace BookApp.Foundation.Helpers
{
    public class AuthorizationModel
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }
        public const string default_username = "user@gmail.com";
        public const string default_email = "user@gmail.com";
        public const string default_password = "Pa$$w0rd.";
        public const Roles default_role = Roles.User;

        public const string admin_username = "admin@gmail.com";
        public const string admin_email = "admin@gmail.com";
        public const string admin_password = "Pa$$w0rd.";
        public const Roles admin_role = Roles.Administrator;
    }
}
