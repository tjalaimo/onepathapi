namespace onepathapi.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string MediaUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public ICollection<PostLike> Likes { get; set; }
        public ICollection<PostComment> Comments { get; set; }
    }
}
