using Microsoft.AspNetCore.Mvc;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;
        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);
            if (user!=null)
            {
                var token = await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("username or password is incorrect!");        
        }
    }
}
