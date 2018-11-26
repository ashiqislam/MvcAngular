using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApp.Data;
using AngularApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userMananger, SignInManager<User> signinManager)
        {
            _userManager = userMananger;
            _signInManager = signinManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserVM user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok("Login succeeded");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserVM user)
        {

            User newUser = new User { UserName = user.UserName };
            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                return Ok(new { Msg = "Registration succeeded", User = newUser.UserName, ID = newUser.Id });
            }
            return BadRequest(result);

        }

    }
}