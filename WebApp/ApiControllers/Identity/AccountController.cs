using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.App.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers.Identity
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<AccountController> logger, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<JwtResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Message>), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.DTO.v1.JwtResponse>> Login([FromBody] PublicApi.DTO.v1.Login dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            // TODO protections against timing attack
            if (user == null)
            {
                _logger.LogWarning("login. user {User} not found", dto.Email);
                return NotFound(new PublicApi.DTO.v1.Message("Email/Password not found"));
            }

            var res = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (res.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                var jwt = Extensions.Base.IdentityExtensions.JwtGenerator(
                    claimsPrincipal.Claims,
                    _configuration["JWT:Key"],
                    _configuration["JWT:Issuer"],
                    _configuration["JWT:Issuer"],
                    DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                );
                _logger.LogInformation("Login. User {User}", dto.Email);
                return Ok(new PublicApi.DTO.v1.JwtResponse()
                {
                    Token = jwt,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname
                });
            }
            
            _logger.LogWarning("login. user {User} bad password", dto.Email);
            return NotFound(new PublicApi.DTO.v1.Message("Email/Password not found"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PublicApi.DTO.v1.Register dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);
            if (appUser != null)
            {
                _logger.LogWarning(" User {User} already registered", dto.Email);
                return BadRequest(new PublicApi.DTO.v1.Message("User already registered"));
            }

            appUser = new Domain.App.Identity.AppUser()
            {
                Email = dto.Email,
                UserName = dto.Email,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
            };
            var result = await _userManager.CreateAsync(appUser, dto.Password);
            
            if (result.Succeeded)
            {
                _logger.LogInformation("User {Email} created a new account with password", appUser.Email);
                
                var user = await _userManager.FindByEmailAsync(appUser.Email);
                if (user != null)
                {                
                    var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                    var jwt = Extensions.Base.IdentityExtensions.JwtGenerator(
                        claimsPrincipal.Claims,
                        _configuration["JWT:Key"],                    
                        _configuration["JWT:Issuer"],
                        _configuration["JWT:Issuer"],
                        DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                    );
                    _logger.LogInformation("WebApi login. User {User}", dto.Email);
                    return Ok(new PublicApi.DTO.v1.JwtResponse()
                    {
                        Token = jwt,
                        Firstname = appUser.Firstname,
                        Lastname = appUser.Lastname,
                    });
                    
                }
                else
                {
                    _logger.LogInformation("User {Email} not found after creation", appUser.Email);
                    return BadRequest(new PublicApi.DTO.v1.Message("User not found after creation!"));
                }
            }
            
            var errors = result.Errors.Select(error => error.Description).ToList();
            return BadRequest(new PublicApi.DTO.v1.Message() {Messages = errors});
        }
        
}
}