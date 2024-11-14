namespace onepathapi.Models
{
    public class PostComment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int PostId { get; set; }
        public int CommentedByUserId { get; set; }
        public Post Post { get; set; }
        public User CommentedByUser { get; set; }
    }
}
