using DA3.Models;

namespace DA3.Service.Contract
{
    public interface ICategoryService
    {
        List<CategoryModel> AllCategories();

        string Create(CategoryModel cartModel);
    }
}
