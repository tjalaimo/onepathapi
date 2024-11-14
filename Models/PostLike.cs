namespace onepathapi.Models
{
    public class PostLike
    {
        public int PostLikeId { get; set; }
        public int PostId { get; set; }
        public int LikedByUserId { get; set; }
        public DateTime LikedDate { get; set; }
        public Post Post { get; set; }
        public User LikedByUser { get; set; }
    }
}
