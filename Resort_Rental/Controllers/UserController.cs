using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Service.UserService;

namespace Resort_Rental.Controllers
{
    [Authorize]
    [ApiController]
    [Route("resort-manager/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("get-user/{userId}")]
        public async Task<IActionResult> GetUser(long userId) 
        {
            var user = await _userService.GetUser(userId);
            return Ok(user);
        }

        [HttpPost]
        [Route("add_new")]
        public async Task<IActionResult> CreateUser(UserDto userDTO)
        {
            await _userService.Create(userDTO);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(UserDto userDTO)
        {
            await _userService.Create(userDTO);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            var userDelete = await _userService.GetUser(userId);
            if (userDelete != null)
            {
                await _userService.Delete(userId);
            }
            return Ok();
        }
    }
}
