namespace DA3.DAL.Domain
{
    public class OrderDetail : BaseDomain
    {
        public Guid Id { get; set; }

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public decimal Amount { get; set; }

        public decimal PricePerProduct { get; set; }

        public double PricePerAllProducts { get; set; }
    }
}
