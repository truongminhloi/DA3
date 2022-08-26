using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IProductService
    {
        List<ProductModel> AllProducts();

        ProductModel GetProductById(string productId);
    }
}
