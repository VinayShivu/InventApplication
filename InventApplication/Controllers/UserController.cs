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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/adduser")]
        public IActionResult RegisterUser([FromBody] UserDto model)
        {
            _userService.RegisterUser(model);
            return new OkObjectResult(new { message = "User Registered" });

        }

        [HttpGet]
        [Route("api/login")]
        public IActionResult Login(string username, string password)
        {
            string responseToken = _userService.UserLogin(username, password);
            if (responseToken == "Invalid Credentials")
            {
                return new BadRequestObjectResult(new { message = "Invalid credentials", currentDate = DateTime.Now });
            }
            return Ok(responseToken);
        }
    }
}
