using AscentBackend.Models;
using AscentBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AscentBackend.Controllers
{
    [Route("ascent/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> FindById(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        // public async Task<ActionResult<User>> findMe(Authentication auth)

        [HttpGet]
        public async Task<ActionResult<User>> FindByEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);
            return Ok(result);
        }

        [HttpGet("recruiter")]
        public async Task<ActionResult<List<User>>> FindAllRecruiters()
        {
            var result = await _userService.GetAllRecruiters();
            return Ok(result);
        }

        [HttpGet("am")]
        public async Task<ActionResult<List<User>>> FindAllAccountManagers()
        {
            var result = await _userService.GetAllAccountManagers();
            return Ok(result);
        }

        [HttpGet("trainer")]
        public async Task<ActionResult<List<User>>> FindAllTrainers()
        {
            var result = await _userService.GetAllTrainers();
            return Ok(result);
        }

        [HttpGet("interviewer")]
        public async Task<ActionResult<List<User>>> FindAllInterviewers()
        {
            var result = await _userService.GetAllInterviewers();
            return Ok(result);
        }

        [HttpPost]
        public void CreateUser(User user)
        {
             _userService.CreateUser(user);
        }

        [HttpPut]
        public void EditUser(User user)
        {
            _userService.EditUser(user);
        }

        [HttpDelete("{id}")]
        public void DisableUser(int id)
        {
            _userService.DisableUser(id);
        }
    }
}
