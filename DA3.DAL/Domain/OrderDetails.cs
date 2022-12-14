namespace DA3.DAL.Domain
{
    public class OrderDetails : BaseDomain
    {
        public virtual Guid Id { get; set; }

        public string? OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual string? ProductId { get; set; }

        //public virtual Product Product { get; set; }

        public virtual double Price { get; set; }

        public virtual int Quantity { get; set; }
    }
}
