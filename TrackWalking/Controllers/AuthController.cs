using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.DTOs.Authentication;
using NZWalks.Interfaces;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository; 

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDtoModel)
        {
            var user = await _userManager.FindByEmailAsync(loginDtoModel.Username);
            if (user != null)
            {
                var checkUserPassword = await _userManager.CheckPasswordAsync(user, loginDtoModel.Password);

                if(checkUserPassword)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles != null && roles.Any())
                    {
                        //Creating a Token
                        var token = _tokenRepository.CreateJwtToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = token
                        };
                        // Return ok with the generated token
                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or Password is incorrect");
        }



    }
}
