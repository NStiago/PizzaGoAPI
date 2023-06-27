using AutoMapper;

namespace PizzaGoAPI.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDTO>();
        }
    }
}
