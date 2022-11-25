using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Resort_Rental.Domain.Dtos.jwtDtos;
using Resort_Rental.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Resort_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuaration;

        public AuthenController(UserManager<AppUser> userManager, IConfiguration configuaration)
        {
            _userManager = userManager;
            _configuaration = configuaration;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginJwtDto loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var expires = DateTime.Now.AddDays(1);
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuaration["Jwt:Key"]));
                // Tạo Token
                var token = new JwtSecurityToken(
                    issuer: _configuaration["Jwt:Issuer"],
                    audience: _configuaration["Jwt:Audience"],
                    expires: expires,
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                //Return token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterJwtDto registerDTO)
        {
            var userExists = await _userManager.FindByNameAsync(registerDTO.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseJwtDto { Status = "Lỗi", Message = "User đã tồn tại" });
            }
            AppUser user = new AppUser()
            {
                UserName = registerDTO.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registerDTO.Email,
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseJwtDto { Status = "Lỗi", Message = "Lỗi tạo tài khoản" });
            }
            return Ok(new ResponseJwtDto { Status = "Thành công", Message = "User được tạo thành công!" });
        }
    }
}
