using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        [NotMapped]
        public User CreatedByUser { get; set; }
        [NotMapped]
        public ICollection<PostLike> Likes { get; set; }
        [NotMapped]
        public ICollection<PostComment> Comments { get; set; }
    }
}
