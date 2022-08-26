using DA3.Models;

namespace DA3.Service.Contract
{
    public interface ICartService
    {
        List<CartModel> AllCarts();

        string Create(CartModel cartModel);

        string CreateCartDetail(CartDetailModel cartModel);

        bool Delete(string Id);

        CartModel GetcartByUserId(string userId);
    }
}
