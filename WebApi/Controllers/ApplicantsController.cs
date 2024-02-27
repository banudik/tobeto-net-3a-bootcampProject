using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantsController : BaseController
{
    private readonly IApplicantService _applicantService;

    public ApplicantsController(IApplicantService applicantService)
    {
        _applicantService = applicantService;
    }

    [HttpPost("AddAsync")]
    public async Task<IActionResult> AddAsync(CreateApplicantRequest request)
    {
        return Ok (await _applicantService.AddAsync(request));
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _applicantService.GetAllAsync());
    }

    [HttpGet("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _applicantService.GetByIdAsync(id));
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeletedAsync(DeleteApplicantRequest request)
    {
        return Ok(await _applicantService.DeleteAsync(request));
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync(UpdateApplicantRequest request)
    {
        return Ok(await _applicantService.UpdateAsync(request));
    }
}