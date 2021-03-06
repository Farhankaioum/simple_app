using System.Collections.Generic;

namespace BookApp.Foundation.DTOs
{
    public class AuthenticationModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; } = false;
        public UserDto User { get; set; }
    }
}
