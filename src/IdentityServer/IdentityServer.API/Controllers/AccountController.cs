using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using IdentityServer.API.JWTFeatures;
using IdentityServer.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        public AccountController(
            UserManager<Account> userManager,
            IMapper mapper,
            JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }
        [HttpPost("Registration")] 
        public async Task<IActionResult> RegisterUser([FromBody] AccountForRegistrationDto userForRegistration) 
        {
            if (userForRegistration == null || !ModelState.IsValid) 
                return BadRequest(); 
            var user = _mapper.Map<Account>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password); 
            if (!result.Succeeded) 
            { 
                var errors = result.Errors.Select(e => e.Description); 
                return BadRequest(new RegistrationResponseDto { Errors = errors }); 
            }
            return StatusCode(201); 
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Login);
            if(user is null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authorization"});
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => Ok(await _userManager.Users.ToListAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
            => Ok(await _userManager.FindByIdAsync(id));
    }
}