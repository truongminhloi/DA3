using DA3.Common;

namespace DA3.DAL.Domain
{
    public class Category : BaseDomain
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }


        public string? Describe { get; set; }

        public virtual List<Product> Products { get; set; }

        public Status Status { get; set; }
    }
}
