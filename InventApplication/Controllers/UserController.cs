using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpPost]
        [Route("api/adduser")]
        public IActionResult RegisterUser([FromBody] UserDto model)
        {
            _userService.RegisterUser(model);
            return new OkObjectResult(new { message = "User Registered" });

        }

        /// <summary>
        /// Get all login response
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("api/login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            _logger.LogInformation("Get All login response");
            TokenResponse tokenResponse = await _userService.UserLogin(username, password);
            if (tokenResponse != null)
            {
                return Ok(tokenResponse);
            }
            else
            {
                return BadRequest(new { message = "Invalid credentials", currentDate = DateTime.Now });
            }
        }
    }
}
