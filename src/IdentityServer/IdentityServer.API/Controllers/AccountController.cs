using System.Security.Claims;
using AutoMapper;
using IdentityServer.API.DTOs;
using IdentityServer.API.Errors;
using IdentityServer.Core.Entities;
using IdentityServer.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(
            UserManager<Account> userManager,
            SignInManager<Account> signInManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<ActionResult<object>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user is null)
                return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(!result.Succeeded)
                return Unauthorized(new ApiResponse(401));
            return new
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<object>> Register(RegisterDto registerDto)
        {
            var user = new Account
            {
                UserName = registerDto.UserName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                MiddleName = registerDto.MiddleName,
                Email = registerDto.Email,
                OrganizationId = registerDto.OrganizationId,
                PhoneNumber = registerDto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded)
                return BadRequest(new ApiResponse(400));
            return new
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpGet("test")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "You are authorize";
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AccountDto>> GetCurentAccount()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<AccountDto>(user);
        }
        [HttpGet("emailexists")]
        [Authorize]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}