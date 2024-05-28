using API.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;

using Models;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;


namespace API.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private DBCon context;
        private IConfiguration _config;
        public UserController(DBCon _context, IConfiguration config)
        {
            context = _context;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<string> GetToken()
        {


            return GenerateJSONWebToken();

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel user)
        {

            try
            {
                User? userExist = await context.Users
                    .Include(x => x.Area)
                    .Include(x => x.Country)
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(x => x.UserName == user.UserName);

                if (userExist == null)
                {
                    return BadRequest();
                }

                SaltedUser saltedUser = await context.SaltedUsers.FirstOrDefaultAsync(x => x.User.Id == userExist.Id);

                if (!VerifyPassword(user.Password, userExist.Password, saltedUser.Salt))
                {
                    return BadRequest();
                }

                return Ok(new TokenUser { Token = GenerateJSONWebToken(), User = userExist });
            }
            catch
            {
                return BadRequest();
            }

        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            string salt;
            user.Password = HashPasswordCreate(user.Password, out salt);

            SaltedUser _user = new SaltedUser() { Salt = salt, User = user };
            try
            {
                user.Country = await context.Countrys.FindAsync(user.Country.Id);
                user.Area = await context.Areas.FindAsync(user.Area.Id);
                user.Role = await context.Roles.FindAsync(user.Role.Id);
                await context.Users.AddAsync(user);



                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this user");
                }

                await context.SaltedUsers.AddAsync(_user);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Error CUser \n" + e.Message);
            }

            return Ok();
        }

        [HttpGet("ReadAllUser")]
        public async Task<IActionResult> ReadAllUser()
        {
            try
            {
                return Ok(context.Users
                    .Include(x => x.Country)
                    .Include(x => x.Area)
                    .Include(x => x.Role)
                    );
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
                return Ok(await context.Users
                    .Include(x => x.Country)
                    .Include(x => x.Area)
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User updatedUser)
        {
            try
            {
                bool oldUser = await context.Users.AnyAsync(x => x.Password == updatedUser.Password);

                if (!oldUser)
                {
                    string salt;
                    updatedUser.Password = HashPasswordCreate(updatedUser.Password, out salt);

                    SaltedUser _user = await context.SaltedUsers.FirstOrDefaultAsync(x => x.User.Id == updatedUser.Id);
                    _user.User = updatedUser;
                    _user.Salt = salt;

                    await Task.Run(() =>
                    {
                        context.SaltedUsers.Update(_user);
                    });


                    await context.SaveChangesAsync();

                }

                await Task.Run(() =>
                {
                    context.Users.Update(updatedUser);
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

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(enteredPassword);
                byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
                Array.Copy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
                Array.Copy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

                byte[] hash = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hash) == storedHash;
            }
        }


        private string HashPasswordGet(string password)
        {
            byte[] salt = GenerateSalt();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
                Array.Copy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
                Array.Copy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

                byte[] hash = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hash);
            }
        }
        private string HashPasswordCreate(string password, out string saltString)
        {
            byte[] salt = GenerateSalt();
            saltString = Convert.ToBase64String(salt);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
                Array.Copy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
                Array.Copy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

                byte[] hash = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hash);
            }
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // 16 bytes = 128 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
