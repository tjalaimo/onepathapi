namespace onepathapi.Services
{
    public interface IUserService
    {
        string Register();
        string Login();
        string Logout();
        object GetCurrentUser();
    }

    public class UserService : IUserService
    {
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
    }
}
