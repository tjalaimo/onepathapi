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

        public virtual User CreatedByUser { get; set; }
        public virtual ICollection<PostLike> Likes { get; set; } = new List<PostLike>();
        public virtual ICollection<PostComment> Comments { get; set; } = new List<PostComment>();
    }
}
