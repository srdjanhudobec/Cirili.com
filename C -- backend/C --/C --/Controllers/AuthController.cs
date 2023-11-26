using AutoMapper;
using C___.DTOs.User;
using C___.Models;
using C___.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace C___.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserService _users;


        public AuthController(
            UserManager<IdentityUser> userManager,
            IMapper mapper,
            IUserService users,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _users = users;
            _mapper = mapper;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost,AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LogInRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = GetToken(authClaims);

                string u = _users.getAllUsers().FirstOrDefault(x => x.Username == model.Username).Username;

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    u
                });
            }
            return Unauthorized();
        }
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        [Route("register-user")]
        public async Task<IActionResult> Register([FromBody] UserPostRequest model)
        {
            //dodavanje u user tabelu

            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            User u = _mapper.Map<User>(_users.createUser(model));
            var createdUser = _users.getAllUsers().FirstOrDefault(x => x.Username == model.Username);
            u.Id = _mapper.Map<User>(createdUser).Id;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("You must enter one UpperCase char,one number and one special character.");


            if (u != null)
            {
                return Ok(u);
            }
            else
            {
                return BadRequest("Failed Creation.");
            }
        }


        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
