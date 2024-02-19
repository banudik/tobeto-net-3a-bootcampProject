using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantController : ControllerBase
{
    private readonly IApplicantService _applicantService;

    public ApplicantController(IApplicantService applicantService)
    {
        _applicantService = applicantService;
    }

    [HttpPost]
    public async Task<CreatedApplicantResponse> AddAsync(CreateApplicantRequest request)
    {
        return await _applicantService.AddAsync(request);
    }

    [HttpDelete]
    public async Task<DeletedApplicantResponse> DeletedAsync(DeleteApplicantRequest request)
    {
        return await _applicantService.DeleteAsync(request);
    }

    [HttpPut]
    public async Task<UpdatedApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        return await _applicantService.UpdateAsync(request);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _applicantService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
    {
        return Ok(await _applicantService.GetByIdAsync(id));
    }
}