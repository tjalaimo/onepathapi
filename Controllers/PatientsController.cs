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
    public async Task<IActionResult> GetPatient(int patientId)
    {
        BasePatientDTO patient = await _patientsService.GetPatient(patientId);
        if (patient != null)
        {
            return Ok(patient);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("getPatientByUserId/{user_id}")]
    public async Task<IActionResult> GetPatientByUserId(int user_id)
    {
        BasePatientDTO patient = await _patientsService.GetPatientByUserId(user_id);
        if (patient != null)
        {
            return Ok(patient);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("getPatients")]
    public async Task<IActionResult> GetPatients([FromBody] PaginationRequest request)
    {
        var (patients, totalPatients) = await _patientsService.GetPatients(request);

        // Return paginated result along with total patient count
        var result = new
        {
            TotalCount = totalPatients,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            Patients = patients
        };

        return Ok(result);
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
