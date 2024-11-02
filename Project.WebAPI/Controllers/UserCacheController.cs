using Microsoft.AspNetCore.Mvc;
using Project.WebAPI.Models;
using Project.WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCacheController : ControllerBase
    {
        private readonly ILogger<UserCacheController> _logger;
        private readonly ICacheService _cacheService;

        public UserCacheController(ICacheService cacheService, ILogger<UserCacheController> logger)
        {
            _cacheService = cacheService;
            _logger = logger;
        }


        // GET: /UserCache/userCache
        [HttpGet("userCache")]
        public async Task<IActionResult> Get(int userId)
        {
            var cacheData = _cacheService.GetData<UserLogInfo>($"userCache_{userId}");

            if (cacheData is not null)
            {
                return Ok(cacheData);
            }

            return NotFound();
        }


        // POST: /UserCache/AddUser
        [HttpPost("AddUser")]
        public async Task<IActionResult> Post(int userId)
        {
            var cacheData = new UserLogInfo(userId);
            var expiryTime = DateTimeOffset.Now.AddDays(30);

            _cacheService.SetData($"userCache_{userId}", cacheData, expiryTime);

            return Ok(cacheData);
        }

        // DELETE: /UserCache/RemoveUser/5
        [HttpDelete("RemoveUserCache/{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var removed = _cacheService.RemoveData($"userCache_{userId}");

            if (removed is not null && (bool)removed)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
