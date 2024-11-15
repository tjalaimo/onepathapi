using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class PostLike
    {
        [Key]
        public int PostLikeId { get; set; }
        public int PostId { get; set; }
        public int LikedByUserId { get; set; }
        public DateTime? LikedDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual User LikedByUser { get; set; }
    }
}
