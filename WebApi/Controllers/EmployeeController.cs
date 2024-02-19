using Business.Abstracts;
using Business.Abstracts.Employee;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<CreatedEmployeeResponse> AddAsync(CreateEmployeeRequest request)
    {
        return await _employeeService.AddAsync(request);
    }

    [HttpDelete]
    public async Task<DeletedEmployeeResponse> DeletedAsync(DeleteEmployeeRequest request)
    {
        return await _employeeService.DeleteAsync(request);
    }

    [HttpPut]
    public async Task<UpdatedEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
    {
        return await _employeeService.UpdateAsync(request);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _employeeService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
    {
        return Ok(await _employeeService.GetByIdAsync(id));
    }
}
