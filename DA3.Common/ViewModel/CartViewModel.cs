namespace DA3.Models
{
    public class CartViewModel
    {
        public double PriceShipFree { get; set; }

        public double PriceShipStandard { get; set; }

        public double PriceShipExpress { get; set; }

        public CartModel CartModel { get; set; } = new CartModel();
    }
}