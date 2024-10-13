using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost("create")]
    public IActionResult CreateAppointment()
    {
        var result = _appointmentService.CreateAppointment();
        return Ok(new { Message = result });
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetUserAppointments(string userId)
    {
        var appointments = _appointmentService.GetUserAppointments(userId);
        return Ok(appointments);
    }

    [HttpPost("checkin")]
    public IActionResult CheckInAppointment()
    {
        var result = _appointmentService.CheckInAppointment();
        return Ok(new { Message = result });
    }
}
