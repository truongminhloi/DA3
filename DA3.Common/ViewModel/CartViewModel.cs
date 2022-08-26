namespace DA3.Models
{
    public class CartViewModel
    {
        public decimal PriceShipFree { get; set; }

        public decimal PriceShipStandard { get; set; }

        public decimal PriceShipExpress { get; set; }

        public CartModel CartModel { get; set; }
    }
}