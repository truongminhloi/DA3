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
            CreateMap<Account, AccountModel>();
            CreateMap<AccountModel, Account>();

            CreateMap<Product, ProductModel>();

            CreateMap<Cart, CartModel>();
            CreateMap<CartDetails, CartDetailModel>();

            CreateMap<CartModel, Cart>();
            CreateMap<CartDetailModel, CartDetails>();


            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();


            CreateMap<Store, StoreModel>();
            CreateMap<StoreModel, Store>();
        }
    }
}
