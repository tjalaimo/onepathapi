namespace onepathapi.Services
{
    public interface IProviderService
    {
        object GetAllProviders();
        object GetProviderDetails(string id);
    }

    public class ProviderService : IProviderService
    {
        public object GetAllProviders()
        {
            return new[]
            {
                new { Id = "P1", Name = "Dr. Smith", Location = "New York", Insurance = "XYZ Insurance" },
                new { Id = "P2", Name = "Dr. Jane Doe", Location = "Los Angeles", Insurance = "ABC Insurance" }
            };
        }

        public object GetProviderDetails(string id)
        {
            return new
            {
                Id = id,
                Name = "Dr. Smith",
                Location = "New York",
                Procedures = new[] { "X-Ray", "MRI" },
                Insurance = "XYZ Insurance"
            };
        }
    }
}