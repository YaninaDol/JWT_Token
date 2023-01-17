using JWT_Token.Data;
using JWT_Token.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ProductController:ControllerBase
    {
        private readonly Data.SmartMarketDbContext _context;


        public ProductController(Data.SmartMarketDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("ProductsList")]
        public async Task<ActionResult<IEnumerable<Product>>> Get() => _context.Products;

    }
}
