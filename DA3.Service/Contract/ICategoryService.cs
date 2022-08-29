using DA3.Models;

namespace DA3.Service.Contract
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAllCategories();

        string Update(CategoryModel categoryModel);

        string Create(CategoryModel cartModel);

        CategoryModel GetCategoryById(string categoryId);
    }
}
