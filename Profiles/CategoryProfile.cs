﻿using AutoMapper;

namespace PizzaGoAPI.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDTO>();
            CreateMap<Entities.Category, Models.CategoryDTOWithoutProduct>();
            CreateMap<Models.CategoryDTOForCreation,Entities.Category>();
        }
    }
}
