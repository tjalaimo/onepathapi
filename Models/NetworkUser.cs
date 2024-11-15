using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class NetworkUser
    {
        [Key]
        public int NetworkUserId { get; set; }
        public int NetworkId { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public Network Network { get; set; }
        [NotMapped]
        public User User { get; set; }
    }
}
