using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IProductService
    {
        List<ProductModel> GetAllProducts();

        ProductModel GetProductById(string productId);

        string Update(ProductModel model);

        string Create(ProductModel model);

    }
}
