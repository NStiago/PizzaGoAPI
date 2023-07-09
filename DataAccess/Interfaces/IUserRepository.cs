using PizzaGoAPI.Entities;
using PizzaGoAPI.Models;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        bool IsValidUserInformation(UserAuth user);
    }
}
