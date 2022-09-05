using DA3.Models;

namespace DA3.Service.Contract
{
    public interface ICartService
    {
        List<CartModel> AllCarts();

        string Create(CartModel cartModel);

        string CreateCartDetail(CartDetailModel cartModel);

        string Update(CartModel model);

        CartModel GetcartByUserId(string userId);
    }
}
