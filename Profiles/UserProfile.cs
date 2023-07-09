using AutoMapper;

namespace PizzaGoAPI.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Models.UserDTOforRegistration,Entities.User>();
        }
    }
}
