using Business.Abstracts.Applications;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : BaseController
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost("AddAsync")]
    public async Task<IActionResult> AddAsync(CreateApplicationRequest request)
    {
        return Ok(await _applicationService.AddAsync(request));
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _applicationService.GetAllAsync());
    }

    [HttpPost("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _applicationService.GetByIdAsync(id));
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync(DeleteApplicationRequest request)
    {
        return Ok(await _applicationService.DeleteAsync(request));
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest request)
    {
        return Ok(await _applicationService.UpdateAsync(request));
    }
}

