using DA3.Common;

namespace DA3.DAL.Domain
{
    public class CategoryProduct
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public Status Status { get; set; }
    }
}
