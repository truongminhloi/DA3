using DA3.Common;

namespace DA3.Models
{
    public class CartDetailModel : BaseModel
    {
        public string Id { get; set; }

        public string CartId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }
        public string Url { get; set; }

        public double PriceProduct { get; set; }

        public double PricePerProdcut { get; set; }

        public Status Status { get; set; }
    }
}
