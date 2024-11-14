namespace onepathapi.Models
{
    public class NetworkUser
    {
        public int NetworkUserId { get; set; }
        public int NetworkId { get; set; }
        public int UserId { get; set; }
        public Network Network { get; set; }
        public User User { get; set; }
    }
}
