using API.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private DBCon context;

        public UserController(DBCon _context)
        {
            context = _context;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user)
        {
            bool userExist = false;
            try
            {
                userExist = await context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password) == null;

                if (!userExist)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok(userExist);

        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                await context.Users.AddAsync(user);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this user");
                }
            }
            catch
            {
                return BadRequest("Error CUser");
            }

            return Ok();
        }

        [HttpGet("ReadAllUser")]
        public async Task<IActionResult> ReadAllUser()
        {
            try
            {
                return Ok(context.Users);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("ReadUser")]
        public async Task<IActionResult> ReadUser(int id)
        {
            try
            {
                return Ok(context.Users.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                await Task.Run(() => {
                    context.Users.Update(user);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                User user = new() { Id = id };
                context.Users.Attach(user);
                context.Users.Remove(user);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
