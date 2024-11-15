using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;
using onepathapi.Models;
using onepathapi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("getAppointment")]
    public async Task<IActionResult> getAppointment(int appointmentID)
    {
        Appointment appointment = await _appointmentService.getAppointment(appointmentID);
        if (appointment != null)
        {
            return Ok(appointment);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
    {
        Appointment result = await _appointmentService.CreateAppointment(appointment);
        return Ok(result);
    }

    [HttpGet("getUserAppointments/{patientId}")]
    public async Task<IActionResult> GetUserAppointments(int patientId)
    {
        IEnumerable<Appointment> appointments = await _appointmentService.GetUserAppointments(patientId);
        return Ok(appointments);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAppointment([FromBody] Appointment appointment)
    {
        Appointment result = await _appointmentService.UpdateAppointment(appointment);
        return Ok(result);
    }
}
