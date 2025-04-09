using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgeBuddyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService, IUserQuery userQuery)
    : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IUserQuery _userQuery = userQuery;

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userQuery.GetUserById(id);

            if (user.Id == Guid.Empty)
                return NotFound("User not found.");

            return Ok(user);
        }

        // GET: api/users/paged
        [HttpGet("paged")]
        public IActionResult GetUsersPaged(int pageNumber = 1, int pageSize = 10)
        {
            var users = _userQuery.GetUsersPaged(pageNumber, pageSize);
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User data is null.");

            try
            {
                var user = _userService.CreateUser(userDto);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{idUser}")]
        public IActionResult UpdateUser(Guid idUser, [FromBody] UserDto userDto)
        {
            if (userDto == null || idUser != userDto.Id)
                return BadRequest("User ID mismatch or user data is null.");

            try
            {
                _userService.UpdateUser(userDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] LoginUserDto loginUserDto)
        {
            if (loginUserDto.Email == null || loginUserDto.Password == null)
                return BadRequest("Email or password data is null.");

            try
            {
                var loginValid = _userService.LoginUser(loginUserDto.Email, loginUserDto.Password);
                if (loginValid.Id == Guid.Empty)
                    return Unauthorized();
                else
                    return Ok(loginValid);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{idUser}")]
        public IActionResult DeleteUser(Guid idUser)
        {
            try
            {
                _userService.DeleteUser(idUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
