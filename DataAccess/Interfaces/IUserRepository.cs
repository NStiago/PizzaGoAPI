using PizzaGoAPI.Entities;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetValidUser(UserDTOAuth user);
        Task<bool> IsInvalidUserLogin(string Login);
    }
}
