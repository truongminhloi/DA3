using DA3.Common;

namespace DA3.Models
{
    public class ProductModel : BaseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }

        public string Describe { get; set; }

        public string Color { get; set; }

        public Status Status { get; set; }

        public List<CategoryModel> CategoryModels { get; set; } = new List<CategoryModel>();
    }
}