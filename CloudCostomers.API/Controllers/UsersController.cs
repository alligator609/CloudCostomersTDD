using CloudCostomers.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCostomers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            return Ok("all good!");
        }
    }
}