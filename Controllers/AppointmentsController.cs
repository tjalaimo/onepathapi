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
        AppointmentDTO appointment = await _appointmentService.getAppointment(appointmentID);
        if (appointment != null)
        {
            return Ok(appointment);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("getPatientAppointments/{patientId}")]
    public async Task<IActionResult> GetPatientAppointments(int patientId)
    {
        IEnumerable<AppointmentDTO> appointments = await _appointmentService.GetPatientAppointments(patientId);
        return Ok(appointments);
    }

    [HttpGet("getProviderAppointments/{providerId}")]
    public async Task<IActionResult> GetProviderAppointments(int providerId)
    {
        IEnumerable<AppointmentDTO> appointments = await _appointmentService.GetProviderAppointments(providerId);
        return Ok(appointments);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDTO appointment)
    {
        BaseAppointmentDTO result = await _appointmentService.CreateAppointment(appointment);
        return Ok(result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentDTO appointment)
    {
        BaseAppointmentDTO result = await _appointmentService.UpdateAppointment(appointment);
        return Ok(result);
    }
}
