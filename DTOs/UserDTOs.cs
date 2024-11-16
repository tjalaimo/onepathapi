using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class BaseUserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string? ProfilePictureURL { get; set; }

        public BaseUserDTO() {}

        public BaseUserDTO(User user)
        {
            UserId = user.UserId;
            UserName = user.Username;
            DisplayName = $"{user.FirstName} {user.LastName}";
            ProfilePictureURL = string.Empty; //TODO store this and find somewhere to put images
        }
    }
}