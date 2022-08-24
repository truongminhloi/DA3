using AutoMapper;
using DA3.DAL.Domain;
using DA3.Models;

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
            CreateMap<LoginModel, Account>();
            CreateMap<Account, Account>();
        }
    }
}
