using Business.Abstracts.Employee;
using Business.Abstracts.Instructor;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Responses.Employee;
using Business.Responses.Instructor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _instructorService;

    public InstructorController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }

    [HttpPost]
    public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest request)
    {
        return await _instructorService.AddAsync(request);
    }

    [HttpDelete]
    public async Task<DeletedInstructorResponse> DeletedAsync(DeleteInstructorRequest request)
    {
        return await _instructorService.DeleteAsync(request);
    }

    [HttpPut]
    public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
    {
        return await _instructorService.UpdateAsync(request);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _instructorService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
    {
        return Ok(await _instructorService.GetByIdAsync(id));
    }
}
