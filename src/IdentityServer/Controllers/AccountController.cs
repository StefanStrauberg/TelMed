using AutoMapper;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AccountController(
            IMapper mapper,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpPost("Registration")] 
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration) 
        {
            if (userForRegistration == null || !ModelState.IsValid) 
                return BadRequest(); 
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password); 
            if (!result.Succeeded) 
            { 
                var errors = result.Errors.Select(e => e.Description); 
                return BadRequest(new RegistrationResponseDto { Errors = errors }); 
            }
            return StatusCode(201); 
        }
    }
}