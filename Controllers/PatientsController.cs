using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;
using onepathapi.Models;
using onepathapi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientsService;

    public PatientsController(IPatientService patientsService)
    {
        _patientsService = patientsService;
    }

    [HttpGet("getPatient/{patientId}")]
    public async Task<IActionResult> getPatient(int patientId)
    {
        Patient appointment = await _patientsService.GetPatient(patientId);
        if (appointment != null)
        {
            return Ok(appointment);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("getPatients")]
    public async Task<IActionResult> getPatients([FromBody] PaginationRequest request)
    {
        IEnumerable<Patient> patients = await _patientsService.GetPatients(request);
        return Ok(patients);        
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
    {
        Patient result = await _patientsService.CreatePatient(patient);
        return Ok(result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdatePatient([FromBody] Patient patient)
    {
        Patient result = await _patientsService.UpdatePatient(patient);
        return Ok(result);
    }
}
