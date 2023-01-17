using JWT_Token.Data;
using JWT_Token.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Token.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController:ControllerBase
    {
        private readonly SmartMarketDbContext _context;

        public AuthenticationController(SmartMarketDbContext context)
        {
            _context = context;
        }
    [HttpPost("LogIn")]
        public IResult LogIn([FromBody] User user)
        {
            User person = _context.Users.Where(x => x.Login.Equals(user.Login) && x.Parol.Equals(user.Parol)).FirstOrDefault();
            if (user is null)
            {
                return Results.BadRequest();
            }
            //user.Login == "admin" && user.Parol == "admin"

            if (person!=null)
            {
                

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(12),
                    signingCredentials: signinCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(new JWTTokenResponse() { Token= tokenString });

           }
            return Results.Unauthorized();

        }

       
    }
}
