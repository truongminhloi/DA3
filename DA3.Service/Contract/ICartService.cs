using DA3.Models;

namespace DA3.Service.Contract
{
    public interface ICartService
    {
        string Create(CartModel cartModel);

        string CreateCartDetail(CartDetailModel cartModel);

        bool Delete(string Id);

        CartModel GetcartById(string userId);
    }
}
