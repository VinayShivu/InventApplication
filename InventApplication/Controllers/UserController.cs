using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.JWT;
using InventApplication.Domain.Models.JWT;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, ILogger<UserController> logger, IJwtService jwtService)
        {
            _userService = userService;
            _logger = logger;
            _jwtService = jwtService;
        }


        [HttpPost]
        [Route("api/register")]
        public IActionResult RegisterUser([FromBody] UserDto model)
        {
            _userService.RegisterUser(model);
            return new OkObjectResult(new { message = "User Registered" });

        }

        /// <summary>
        /// Get all login
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("api/login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            _logger.LogInformation("Get All login response");
            JwtToken tokenResponse = await _userService.UserLogin(username, password);
            if (tokenResponse != null)
            {
                return Ok(tokenResponse);
            }
            else
            {
                return BadRequest(new { message = "Invalid credentials", currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get refresh token
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("api/refreshtoken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            _logger.LogInformation("Get Refreshtoken response");
            JwtToken tokenResponse = await _jwtService.GetRefreshToken(request);
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
