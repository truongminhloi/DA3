using DA3.Common;

namespace DA3.Models
{
    public class CategoryModel : BaseModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Describe { get; set; }

        public Status Status { get; set; }
    }
}