using BookApp.Foundation.DTOs;
using System.Threading.Tasks;

namespace BookApp.Foundation.Services
{
    public interface IUserService
    {
        public Task<AuthenticationModel> GetTokenAsync(LoginModel model);
        public Task<bool> RegisterAsync(RegisterModel model);
    }
}
