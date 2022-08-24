using AutoMapper;
using DA3.DAL.Domain;
using DA3.Service.Request;

namespace DA3.Infrastructure.Mappings
{
    public class DA3ModelMapper
    {
        public static void MappingDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<CreateProductRequest, Product>()
                .ForMember(x=>x.Id, opt => opt.Ignore());
        }
    }
}
