using BookApp.Foundation.DTOs;
using BookApp.Foundation.Entities;
using BookApp.Foundation.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookApp.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserManager<ApplicationUser> userManager,
                              IUserService userService,
                              ILogger<AuthController> logger)
            : base(userManager)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            if (!result)
                return BadRequest("Error Occured!");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetTokenAsync(LoginModel model)
        {
            try
            {
                var result = await _userService.GetTokenAsync(model);
                if (!result.IsAuthenticated)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message, ex);
            }

            return BadRequest();
        }
    }
}
