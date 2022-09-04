using DA3.Common;

namespace DA3.DAL.Domain
{
    public class Product : BaseDomain
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string? Url { get; set; }

        public double Price { get; set; }

        public string? Describe { get; set; }

        public string? Color { get; set; }

        //public virtual List<Favorite>? Favorites { get; set; }

        //public virtual List<CartDetails>? CartDetails { get; set; }

        //public virtual List<OrderDetails>? OrderDetails { get; set; }

        public Status Status { get; set; }
    }
}
