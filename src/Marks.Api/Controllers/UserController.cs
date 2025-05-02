using Marks.Application.Dto.User;
using Marks.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var token = await _userService.Authenticate(userLoginDto.Email, userLoginDto.Password);
            if (token == null)
                return Unauthorized(new { message = "Username or password is incorrect" });
            return Ok(token);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UserUpdateDto user)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, user);
            return Ok(updatedUser);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
