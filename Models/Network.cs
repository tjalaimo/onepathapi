namespace onepathapi.Models
{
    public class Network
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<NetworkUser> Members { get; set; }
    }
}
