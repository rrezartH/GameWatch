using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using GameWatchAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameWatchAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Useri> _userManager;
        private readonly SignInManager<Useri> _signInManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<Useri> userManager, SignInManager<Useri> signInManager,
            TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                return BadRequest("Username taken");
            }

            var user = new Useri
            {
                Emri = registerDto.Emri,
                Email = registerDto.Email,
                UserName = registerDto.Username,
                Qyteti = registerDto.Qyteti,
                RoleName = "Klient",
                BiznesiId = registerDto.BiznesiId
            };

            var results = await _userManager.CreateAsync(user, registerDto.Password);

            if (results.Succeeded)
            {
                return CreateUserObject(user);
            }
            return BadRequest("Problem registering user");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }

        private UserDto CreateUserObject(Useri user)
        {
            return new UserDto
            {
                Emri = user.Emri,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
                RoleName = user.RoleName
            };
        }
    }
}
