using Microsoft.EntityFrameworkCore;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DBContext;
using PizzaGoAPI.Entities;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.DataAccess.Repositories
{
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        public UserRepository(PizzaAppContext context) : base(context)
        {

        }

        public bool IsValidUserInformation(UserAuth user)
        {
            if (_context.Users.Any(x => x.Login == user.Login && x.Password == user.Password))
                return true;
            else
                return false;
        }

        public async Task<User> GetValidUser(UserAuth user)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login && x.Password == user.Password);
        }
    }
}
