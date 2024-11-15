using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class Network
    {
        [Key]
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<NetworkUser> Members { get; set; }
    }
}
