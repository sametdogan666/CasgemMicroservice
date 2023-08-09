using System.Linq;
using CasgemMicroservice.IdentityServer.DTOs;
using CasgemMicroservice.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace CasgemMicroservice.IdentityServer.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                FullName = signUpDto.FullName,
                UserName = signUpDto.UserName,
                Email = signUpDto.Email,
                City = signUpDto.City
            };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);

            return Ok(result.Succeeded ? "Kullanıcı kaydı oluşturuldu" : "Kullanıcı oluşturulurken bir hata oluştu");
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
           
            var user = await _userManager.FindByIdAsync(claim.Value);
            
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                City = user.City
            });
        }
    }
}
