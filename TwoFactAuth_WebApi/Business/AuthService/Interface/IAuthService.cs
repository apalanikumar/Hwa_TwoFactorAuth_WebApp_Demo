using TwoFactAuth_WebApi.Models;

namespace TwoFactAuth_WebApi.Business.AuthService.Interface
{
    public interface IAuthService
    {
        public Task<User> Login(string email, string password);
        public Task<User> Register(User user);
    }
}
