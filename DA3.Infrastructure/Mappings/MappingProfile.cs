using AutoMapper;
using DA3.DAL.Domain;
using DA3.Service.Dto;
using DA3.Service.Request;

namespace DA3.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ProductMapping();
        }

        private void ProductMapping()
        {
            CreateMap<Product, Product>();

            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
