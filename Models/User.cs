namespace onepathapi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store passwords as hashes
        public string UserType { get; set; } // "Patient" or "Provider"
        public int? PatientId { get; set; }
        public int? ProviderId { get; set; }
        public Patient Patient { get; set; }
        public Provider Provider { get; set; }
        public ICollection<AccessCode> GeneratedAccessCodes { get; set; }
        public ICollection<AccessCode> ReceivedAccessCodes { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostLike> LikedPosts { get; set; }
        public ICollection<PostComment> Comments { get; set; }
        public ICollection<NetworkUser> NetworkMemberships { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
