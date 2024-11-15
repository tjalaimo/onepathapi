using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class AccessCode
    {
        [Key]
        public int AccessCodeId { get; set; }
        public string Code { get; set; }
        public string CodeType { get; set; } // "Permanent" or "Temporary"
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GeneratorUserId { get; set; }
        public int RecipientUserId { get; set; }
        [NotMapped]
        public User GeneratorUser { get; set; }
        [NotMapped]
        public User RecipientUser { get; set; }
    }
}
