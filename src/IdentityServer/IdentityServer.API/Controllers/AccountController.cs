using AutoMapper;
using IdentityServer.API.DTOs;
using IdentityServer.API.Errors;
using IdentityServer.API.Extensions;
using IdentityServer.Core.Entities;
using IdentityServer.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public async Task<ActionResult<object>> Login(LoginDto loginDto)
        {
            var account = await _userManager.FindByEmailAsync(loginDto.Email);
            if(account is null)
                return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(account, loginDto.Password, false);
            if(!result.Succeeded)
                return Unauthorized(new ApiResponse(401));
            return new
            {
                UserName = account.UserName,
                Token = _tokenService.CreateToken(account),
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<object>> Register(RegisterDto registerDto)
        {
            var account = _mapper.Map<Account>(registerDto);
            var result = await _userManager.CreateAsync(account, registerDto.Password);
            if(!result.Succeeded)
                return BadRequest(new ApiResponse(400));
            return new
            {
                UserName = account.UserName,
                Token = _tokenService.CreateToken(account)
            };
        }
        [HttpGet("CurrentAccount")]
        public async Task<ActionResult<AccountDto>> GetCurentAccount()
        {
            var account = await _userManager.FindByEmailFromClaimsAsync(User);
            return _mapper.Map<AccountDto>(account);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccountById(Guid id)
        {
            var account = await _userManager.FindByIdAsync(id.ToString());
            if(account is null)
                return BadRequest(new ApiResponse(400));
            return _mapper.Map<AccountDto>(account);
        }
        [HttpGet]
        [Route("GetAccountSpecializationById/{id}")]
        public async Task<ActionResult<object>> GetAccountSpecializationById(Guid id)
        {
            var account = await _userManager.FindByIdAsync(id.ToString());
            if(account is null)
                return BadRequest(new ApiResponse(400));
            return new { specializationId = account.SpecializationId };
        }
        [HttpGet]
        [Route("GetAccountOrganizationById/{id}")]
        public async Task<ActionResult<object>> GetAccountOrganizationById(Guid id)
        {
            var account = await _userManager.FindByIdAsync(id.ToString());
            if(account is null)
                return BadRequest(new ApiResponse(400));
            return new { organizationId = account.OrganizationId };
        }
    }
}