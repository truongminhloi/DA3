using DA3.Common;

namespace DA3.DAL.Domain
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }

        public double PricePerProduct { get; set; }

        public double PricePerAllProducts { get; set; }

        public Status Status { get; set; }
    }
}
