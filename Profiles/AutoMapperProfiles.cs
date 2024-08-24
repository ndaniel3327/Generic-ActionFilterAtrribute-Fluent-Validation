using AutoMapper;
using BookzoneProjNituDaniel.Models;
using BookzoneProjNituDaniel.Models.DTO.Product;
using BookzoneProjNituDaniel.Models.Input.OrderProduct;
using BookzoneProjNituDaniel.Models.Input.Product;

namespace BookzoneProjNituDaniel.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateProductInput, Product>();
            CreateMap<UpdateProductInput, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductDetailsDTO>();

            CreateMap<CreateOrderProductInput, OrderProduct>();
        }
    }
}
