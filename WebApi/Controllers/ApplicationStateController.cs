using Business.Abstracts.Applications;
using Business.Abstracts.ApplicationStates;
using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationStateController : ControllerBase
{
    private readonly IApplicationStateService _applicationStateService;

    public ApplicationStateController(IApplicationStateService applicationStateService)
    {
        _applicationStateService = applicationStateService;
    }

    [HttpPost("AddAsync")]
    public async Task<IActionResult> AddAsync(CreateApplicationStateRequest request)
    {
        return Ok(await _applicationStateService.AddAsync(request));
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _applicationStateService.GetAllAsync());
    }

    [HttpPost("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _applicationStateService.GetByIdAsync(id));
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync(DeleteApplicationStateRequest request)
    {
        return Ok(await _applicationStateService.DeleteAsync(request));
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync(UpdateApplicationStateRequest request)
    {
        return Ok(await _applicationStateService.UpdateAsync(request));
    }
}