using AutoMapper;
using DA3.Common;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DA3.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public CategoryService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<CategoryModel> GetAllCategories()
        {
            try
            {
                var allCategoryEntities = _dbContext.Categories.AsNoTracking().Where(x => x.Status != Status.DELETE).ToList() ?? new List<Category>();
                var allCategories = _mapper.Map<List<Category>, List<CategoryModel>>(allCategoryEntities);

                return allCategories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Create(CategoryModel categoryModel)
        {
            try
            {
                var CategoryEntity = _mapper.Map<CategoryModel, Category>(categoryModel);
                _dbContext.Categories.AddAsync(CategoryEntity);
                _dbContext.SaveChanges();
                return CategoryEntity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Update(CategoryModel categoryModel)
        {
            try
            {
                var categoryEntity = _mapper.Map<CategoryModel, Category>(categoryModel);
                _dbContext.Categories.Update(categoryEntity);
                _dbContext.SaveChanges();
                return categoryEntity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public CategoryModel GetCategoryById(string categoryId)
        {
            try
            {
                var categoryEntity = _dbContext.Categories.AsNoTracking().FirstOrDefault(x => x.Id == new Guid(categoryId)) ?? new Category();
                var category = _mapper.Map<Category, CategoryModel>(categoryEntity);

                return category;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
