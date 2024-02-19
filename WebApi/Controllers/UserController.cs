using Business.Abstracts.Instructor;
using Business.Abstracts.User;
using Business.Requests.Instructor;
using Business.Requests.User;
using Business.Responses.Instructor;
using Business.Responses.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<CreatedUserResponse> AddAsync(CreateUserRequest request)
    {
        return await _userService.AddAsync(request);
    }

    [HttpDelete]
    public async Task<DeletedUserResponse> DeletedAsync(DeleteUserRequest request)
    {
        return await _userService.DeleteAsync(request);
    }

    [HttpPut]
    public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        return await _userService.UpdateAsync(request);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }
}
