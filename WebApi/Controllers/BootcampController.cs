using Business.Abstracts.ApplicationStates;
using Business.Abstracts.Bootcamps;
using Business.Requests.ApplicationStates;
using Business.Requests.Bootcamps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BootcampController : ControllerBase
{
    private readonly IBootcampService _bootcampService;

    public BootcampController(IBootcampService bootcampService)
    {
        _bootcampService = bootcampService;
    }

    [HttpPost("AddAsync")]
    public async Task<IActionResult> AddAsync(CreateBootcampRequest request)
    {
        return Ok(await _bootcampService.AddAsync(request));
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _bootcampService.GetAllAsync());
    }

    [HttpPost("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _bootcampService.GetByIdAsync(id));
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync(DeleteBootcampRequest request)
    {
        return Ok(await _bootcampService.DeleteAsync(request));
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync(UpdateBootcampRequest request)
    {
        return Ok(await _bootcampService.UpdateAsync(request));
    }
}
