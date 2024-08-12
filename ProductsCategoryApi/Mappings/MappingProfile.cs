// importing namespaces
using AutoMapper;
using ProductsCategoryApi.DTOs;
using ProductsCategoryApi.Models;

// current namespace
namespace ProductsCategoryApi.Mappings
{
    public class MappingProfile: Profile
    {
        // constructor
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
