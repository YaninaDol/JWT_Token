using JWT_Token.Data;
using JWT_Token.Models;

namespace JWT_Token.Controllers
{
    public class UserController
    {
        public List<User>users;
        public UserController()
        {
            users = new Data.SmartMarketDbContext().Users.ToList();
        }
    }
}
