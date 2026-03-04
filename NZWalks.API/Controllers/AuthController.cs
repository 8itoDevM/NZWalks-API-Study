using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        public UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository) {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        // POST: /API/Auth/Register
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto) {
            var identityUser = new IdentityUser {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if(identityResult.Succeeded) {
                // Add roles to user
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any()) {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if(identityResult.Succeeded) {
                        return Ok("User was registered");
                    }
                }
            }

            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        // POST: /api/Auth/Login
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto) {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if(user != null) {
                var checkPassoWord = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if(checkPassoWord) {
                    // Get roles for user
                    var roles = await userManager.GetRolesAsync(user);
                    if(roles != tokenRepository) {
                        // Create token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var res = new LoginResponseDto {
                            JwtToken = jwtToken,
                        };

                        return Ok(res);
                    }
                }
            }
            return BadRequest("Username or Password incorrect");
        }
    }
}
