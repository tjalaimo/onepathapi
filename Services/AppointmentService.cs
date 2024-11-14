using onepathapi.Data;
using onepathapi.Models;
using Microsoft.EntityFrameworkCore;

namespace onepathapi.Services
{
    public interface IAppointmentService
    {
        string CreateAppointment();
        object GetUserAppointments(string userId);
        string CheckInAppointment();
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CreateAppointment()
        {
            return "Appointment created successfully!";
        }

        public object GetUserAppointments(string userId)
        {
            return new[]
            {
                new { Id = "A1", Date = "2024-10-14", Time = "10:00 AM", Provider = "Dr. Smith" },
                new { Id = "A2", Date = "2024-10-15", Time = "2:00 PM", Provider = "Dr. Jane Doe" }
            };
        }

        public string CheckInAppointment()
        {
            return "Check-in completed successfully!";
        }
    }
}
