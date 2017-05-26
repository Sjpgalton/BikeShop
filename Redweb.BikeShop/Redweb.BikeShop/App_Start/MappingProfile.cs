using AutoMapper;
using Redweb.BikeShop.Core.Models;
using Redweb.BikeShop.Core.Models.DatabaseModels;

namespace Redweb.BikeShop.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Size, SizeModel>();
            Mapper.CreateMap<Colour, ColourModel>();
            Mapper.CreateMap<Product, ProductModel>();
            Mapper.CreateMap<Model, ProductModelModel>();
            Mapper.CreateMap<Subcategory, SubcategoryModel>();
            Mapper.CreateMap<Category, CategoryModel>();

            Mapper.CreateMap<SizeModel, Size>();
            Mapper.CreateMap<ColourModel, Colour>();
            Mapper.CreateMap<ProductModel, Product>();
            Mapper.CreateMap<ProductModelModel, Model>();
            Mapper.CreateMap<SubcategoryModel, Subcategory>();
            Mapper.CreateMap<CategoryModel, Category>();
        }
    }
}