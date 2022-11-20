using Microsoft.AspNetCore.Mvc;
using Resort_Rental.Domain.Dto;
using Resort_Rental.Service.UserService;

namespace Resort_Rental.Controllers
{
    [ApiController]
    [Route("manager_resort")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetUser(long userId) 
        {
            var user = await _userService.GetUser(userId);
            return Ok(user);
        }

        [HttpPost]
        [Route("add_new")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            await _userService.Create(userDTO);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            await _userService.Create(userDTO);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            var userDelete = await _userService.GetUser(userId);
            if (userDelete != null)
            {
                await _userService.Delete(userDelete);
            }
            return Ok();
        }
    }
}
