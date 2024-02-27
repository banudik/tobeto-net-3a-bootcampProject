using Business.Abstracts.ApplicationStates;
using Business.Abstracts.Blacklists;
using Business.Requests.ApplicationStates;
using Business.Requests.Blacklists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistsController : BaseController
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistsController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CreateBlacklistRequest request)
        {
            return Ok(await _blacklistService.AddAsync(request));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _blacklistService.GetAllAsync());
        }

        [HttpPost("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _blacklistService.GetByIdAsync(id));
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(DeleteBlacklistRequest request)
        {
            return Ok(await _blacklistService.DeleteAsync(request));
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateBlacklistRequest request)
        {
            return Ok(await _blacklistService.UpdateAsync(request));
        }
    }
}
