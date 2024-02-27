using Business.Abstracts.Bootcamps;
using Business.Abstracts.BootcampStates;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BootcampStatesController : BaseController
{
    private readonly IBootcampStateService _bootcampStateService;

    public BootcampStatesController(IBootcampStateService bootcampStateService)
    {
        _bootcampStateService = bootcampStateService;
    }

    [HttpPost("AddAsync")]
    public async Task<IActionResult> AddAsync(CreateBootcampStateRequest request)
    {
        return Ok(await _bootcampStateService.AddAsync(request));
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _bootcampStateService.GetAllAsync());
    }

    [HttpPost("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _bootcampStateService.GetByIdAsync(id));
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync(DeleteBootcampStateRequest request)
    {
        return Ok(await _bootcampStateService.DeleteAsync(request));
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync(UpdateBootcampStateRequest request)
    {
        return Ok(await _bootcampStateService.UpdateAsync(request));
    }
}
