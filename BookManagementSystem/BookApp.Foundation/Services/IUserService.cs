using BookApp.Foundation.DTOs;
using BookApp.Foundation.Entities;
using System.Threading.Tasks;

namespace BookApp.Foundation.Services
{
    public interface IUserService
    {
        public Task<AuthenticationModel> GetTokenAsync(LoginModel model);
        public Task<bool> RegisterAsync(RegisterModel model);
        public Task<bool> UpdateUser(UserDto model, string userId);
        public Task<bool> DeleteUser(string userId);
    }
}
