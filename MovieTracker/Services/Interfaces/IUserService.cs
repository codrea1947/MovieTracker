using MovieTracker.Models.Entities;

namespace MovieTracker.Services.Interfaces
{
    public interface IUserService
    {
        public Task<string> RegisterUser(User user);

        public Task<string> LogIn (string email, string password);  
    }
}
