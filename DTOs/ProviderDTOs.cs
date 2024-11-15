using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class BaseProviderDTO
    {
        public int ProviderId { get; set; }
        public string Identifier { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Specialty { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public BaseProviderDTO(Provider provider)
        {
            ProviderId = provider.ProviderId;
            Identifier = provider.Identifier;
            FirstName = provider.FirstName;
            LastName = provider.LastName;
            Gender = provider.Gender;
            Specialty = provider.Specialty;
            Email = provider.Email;
            Address = provider.Address;
        }
    }
}