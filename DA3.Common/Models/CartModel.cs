using DA3.Common;
using DA3.Common.Enums;

namespace DA3.Models
{
    public class CartModel : BaseModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public double PricePerAllProducts { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public List<CartDetailModel> CartDetails { get; set; } = new List<CartDetailModel>();

        public Status Status { get; set; }
    }
}