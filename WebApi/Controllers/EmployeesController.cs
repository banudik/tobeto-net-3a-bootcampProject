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
public class EmployeesController : BaseController
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("AddAsync")]
    public async Task<IActionResult> AddAsync(CreateEmployeeRequest request)
    {
        return Ok (await _employeeService.AddAsync(request));
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _employeeService.GetAllAsync());
    }

    [HttpGet("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _employeeService.GetByIdAsync(id));
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeletedAsync(DeleteEmployeeRequest request)
    {
        return Ok(await _employeeService.DeleteAsync(request));
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync(UpdateEmployeeRequest request)
    {
        return Ok(await _employeeService.UpdateAsync(request));
    }
}
