using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class PostComment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime? CommentDate { get; set; }
        public int PostId { get; set; }
        public int CommentedByUserId { get; set; }
        
        public virtual Post Post { get; set; }
        public virtual User CommentedByUser { get; set; }
    }
}
