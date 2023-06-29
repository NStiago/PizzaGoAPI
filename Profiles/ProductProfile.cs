using AutoMapper;

namespace PizzaGoAPI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductDTO>();
            CreateMap<Models.ProductDTOForCreation, Entities.Product>();
        }
    }
}
