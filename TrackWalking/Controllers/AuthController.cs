using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.DTOs.Authentication;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDtoModel)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerDtoModel.Username,
                Email = registerDtoModel.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerDtoModel.Password);

            if (identityResult.Succeeded)
            {
                if (registerDtoModel.Roles != null && registerDtoModel.Roles.Any()) 
                {
                    identityResult =  await _userManager.AddToRolesAsync(identityUser, registerDtoModel.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User Registered, You can login Now");
                    }
                }
            }

            return BadRequest("Something Went wrong");
            
        }


    }
}
