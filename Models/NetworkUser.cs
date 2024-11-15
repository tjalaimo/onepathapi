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

        public virtual Network Network { get; set; }
        public virtual User User { get; set; }
    }
}
