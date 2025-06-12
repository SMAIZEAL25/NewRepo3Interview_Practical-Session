using Interview_Practical_Session.DLL;
using Interview_Practical_Session.NewFolder;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interview_Practical_Session.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UsersController>  
        [HttpGet]
        public async Task<IEnumerable<User>> Get(User user)
        {
            if (user == null)
            {
                return new List<User>();
            }
            return await userService.GetAllAsync();
        }

        // GET api/<UsersController>/5  
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user ID");
            }
            var user = await userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok($"User found: {user.FirstName} {user.Lastname}");
        }

        // POST api/<UsersController>  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data cannot be null or empty");
            }
            var createdUser = await userService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        // PUT api/<UsersController>/5  
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (id <= 0 || user == null)
            {
                return BadRequest("Invalid input");
            }
            var updatedUser = await userService.UpdateAsync(user);
            if (updatedUser == null)
            {
                return NotFound("User not found");
            }
            return Ok(updatedUser);
        }

        // DELETE api/<UsersController>/5  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user ID");
            }
            var user = await userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var isDeleted = await userService.DeleteAsync(user);
            if (!isDeleted)
            {
                return StatusCode(500, "Error deleting user");
            }
            return NoContent();
        }
    }
}
