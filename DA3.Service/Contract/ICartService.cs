using DA3.Models;

namespace DA3.Service.Contract
{
    public interface ICartService
    {
        bool Create(CartModel cartModel);

        bool Delete(string Id);
    }
}
