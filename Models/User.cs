using System.ComponentModel.DataAnnotations;

namespace onepathapi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; } // Store passwords as hashes
        public string? UserType { get; set; } // "Patient" or "Provider"
        public int? PatientId { get; set; }
        public int? ProviderId { get; set; }
        
        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<PostLike> LikedPosts { get; set; } = new List<PostLike>();
        public virtual ICollection<PostComment> Comments { get; set; } = new List<PostComment>();
        public virtual ICollection<NetworkUser> NetworkMemberships { get; set; } = new List<NetworkUser>();
        public virtual ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public virtual ICollection<MessageThread> InitiatedThreads { get; set; } = new List<MessageThread>();
        public virtual ICollection<MessageThread> ReceivedThreads { get; set; } = new List<MessageThread>();
        public virtual ICollection<AccessCode> GeneratedAccessCodes { get; set; } = new List<AccessCode>();
        public virtual ICollection<AccessCode> ReceivedAccessCodes { get; set; } = new List<AccessCode>();
    }
}
