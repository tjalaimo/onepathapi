namespace onepathapi.Models
{
    public class AccessCode
    {
        public int AccessCodeId { get; set; }
        public string Code { get; set; }
        public string CodeType { get; set; } // "Permanent" or "Temporary"
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GeneratorUserId { get; set; }
        public int RecipientUserId { get; set; }
        public User GeneratorUser { get; set; }
        public User RecipientUser { get; set; }
    }
}
