﻿using API.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Models;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static Org.BouncyCastle.Math.EC.ECCurve;

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
            User? userExist = new();
            try
            {
                userExist = await context.Users
                    .Include(x => x.Area)
                    .Include(x => x.Country)
                    .FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);

                if (userExist == null)
                {
                    return BadRequest();
                }           

                return Ok((userExist, GenerateJSONWebToken()));

            }
            catch
            {
                return BadRequest();
            }           

        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
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
    }
}
