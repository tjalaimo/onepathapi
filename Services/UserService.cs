using onepathapi.Data;
using onepathapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace onepathapi.Services
{
    public interface IUserService
    {
        string Register();
        string Login();
        string Logout();
        object GetCurrentUser();
        User GetUser(int userId);
    }

    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public string Register()
        {
            return "User registered successfully!";
        }

        public string Login()
        {
            return "dummy-jwt-token";
        }

        public string Logout()
        {
            return "User logged out successfully!";
        }

        public object GetCurrentUser()
        {
            return new
            {
                Id = "123",
                Name = "John Doe",
                Email = "john.doe@example.com",
                Posts = new[] { "Post1", "Post2" },
                Networks = new[] { "Network1", "Network2" }
            };
        }

        public User GetUser(int userId)
        {            
            return _context.Users.Where(u => u.UserId == userId).FirstOrDefault() ?? new User();            
        }
    }
}
