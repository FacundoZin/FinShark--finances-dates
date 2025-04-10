using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IaccountService _Accountservice;

        public AccountController(IaccountService accountservice)
        {
            _Accountservice = accountservice;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var User = await _Accountservice.LoginAsync(login);

            if (!User.Success) return Unauthorized(User.errormessage);

            return Ok(User);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _Accountservice.RegisterAsync(register);

            if (!user.Success) return StatusCode(500, user.errormessage);

            return Ok(user);
        }
    }
}