using DA3.Common;

namespace DA3.Models
{
    public class CartModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string ProductId { get; set; }

        public int Amount { get; set; }

        public double PricePerProduct { get; set; }

        public double PricePerAllProducts { get; set; }

        public Status Status { get; set; }
    }
}