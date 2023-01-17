using JWT_Token.Data;
using JWT_Token.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController:ControllerBase
    {
        private readonly SmartMarketDbContext _context;
        private readonly HashController hashController = new HashController();
        public RegistrationController(SmartMarketDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        
        public IResult Add([FromForm] string Login, [FromForm] string Password)
        {
           
            if (_context.Users.Any(x => x.Login.Equals(Login) && x.Parol.Equals(Password)) == false)

            {
               
                string hash = hashController.HashPassword(Password);
                _context.Users.Add(new User() { Login=Login,Parol= hash });
                _context.SaveChanges();
                return Results.Ok();

            }
            return Results.BadRequest();
        }

    }
}
