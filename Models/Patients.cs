namespace onepathapi.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public string Communication { get; set; }
    }
}
