using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public BaseUserDTO CreatedByUser { get; set; } 
        public int LikesCount { get; set; }
        public int CommentCount { get; set; }
        public string? CommentPreview { get; set; }
        public IEnumerable<PostCommentDTO>? Comments { get; set; }

        public PostDTO() {}

        public PostDTO(Post post)
        {
            PostId = post.PostId;
            Content = post.Content;
            MediaUrl = post.MediaUrl;
            CreatedDate = post.CreatedDate;
            CreatedByUser = new BaseUserDTO(post.CreatedByUser);
            LikesCount = post.Likes != null ? post.Likes.Count() : 0;
            CommentCount = post.Comments != null ? post.Comments.Count() : 0;
            CommentPreview = post.Comments != null ? post.Comments.OrderByDescending(c => c.CommentDate).Take(1).Select(c => c.CommentText).FirstOrDefault() : string.Empty;
            Comments = post.Comments != null ? post.Comments.Select(pc => new PostCommentDTO(pc)).ToList() : null;
        }
    }
    
    public class PostCommentDTO
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime? CommentDate { get; set; }
        public int PostId { get; set; }
        public BaseUserDTO CommentedByUser { get; set; }

        public PostCommentDTO() {}

        public PostCommentDTO(PostComment postComment)
        {
            CommentId = postComment.CommentId;
            CommentText = postComment.CommentText;
            CommentDate = postComment.CommentDate;
            PostId = postComment.PostId;
            CommentedByUser = new BaseUserDTO(postComment.CommentedByUser);
        }
    }
}

    