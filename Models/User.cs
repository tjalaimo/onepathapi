using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store passwords as hashes
        public string? UserType { get; set; } // "Patient" or "Provider"
        public int? PatientId { get; set; }
        public int? ProviderId { get; set; }
        [NotMapped]
        public Patient Patient { get; set; }
        [NotMapped]
        public Provider Provider { get; set; }
        [NotMapped]
        public ICollection<AccessCode> GeneratedAccessCodes { get; set; }
        [NotMapped]
        public ICollection<AccessCode> ReceivedAccessCodes { get; set; }
        [NotMapped]
        public ICollection<Post> Posts { get; set; }
        [NotMapped]
        public ICollection<PostLike> LikedPosts { get; set; }
        [NotMapped]
        public ICollection<PostComment> Comments { get; set; }
        [NotMapped]
        public ICollection<NetworkUser> NetworkMemberships { get; set; }
        [NotMapped]
        public ICollection<Message> SentMessages { get; set; }
        [NotMapped]
        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
