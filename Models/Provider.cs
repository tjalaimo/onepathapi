using System.ComponentModel.DataAnnotations;

namespace onepathapi.Models
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }
        public string Identifier { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Specialty { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
