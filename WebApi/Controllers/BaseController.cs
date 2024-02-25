using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    public IActionResult HandleDataResult<T>(IDataResult<T> dataResult)
    {
        return dataResult.Success ? Ok(dataResult) : BadRequest(dataResult);
    }
}
