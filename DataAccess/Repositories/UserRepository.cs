using AutoMapper;
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

        public async Task<bool> IsInvalidUserLogin(string Login)
        {
            return await _context.Users.AnyAsync(x => x.Login == Login);
        }

        public async Task<User> GetValidUser(UserDTOAuth user)
        {
            var resultUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login);
            if (resultUser == null)
                return null;
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.Password, resultUser.Password);

            if (isValidPassword)
                return resultUser;
            return null;
        }
    }
}
