using PizzaGoAPI.Entities;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetValidUser(UserAuth user);
        bool IsValidUserInformation(UserAuth user);
    }
}
