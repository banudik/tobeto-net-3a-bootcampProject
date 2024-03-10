using Business.Abstracts;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("Employee Register")]
    public async Task<IActionResult> EmployeeRegister(EmployeeForRegisterDto employeeForRegisterDto)
    {
        var result = await _authService.EmployeeRegister(employeeForRegisterDto);
        return HandleDataResult(result);
    }

    [HttpPost("Instructor Register")]
    public async Task<IActionResult> InstructorRegister(InstructorForRegisterDto instructorForRegisterDto)
    {
        var result = await _authService.InstructorRegister(instructorForRegisterDto);
        return HandleDataResult(result);
    }

    [HttpPost("Applicant Register")]
    public async Task<IActionResult> ApplicantRegister(ApplicantForRegisterDto applicantForRegisterDto)
    {
        var result = await _authService.ApplicantRegister(applicantForRegisterDto);
        return HandleDataResult(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
        var result = await _authService.Login(userForLoginDto);
        return HandleDataResult(result);
    }


}
