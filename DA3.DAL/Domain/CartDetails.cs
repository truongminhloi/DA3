using DA3.Common;

namespace DA3.DAL.Domain
{
    public class CartDetails : BaseDomain
    {
        public Guid Id { get; set; }

        public string CartId { get; set; }

        public Cart Cart { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public Status Status { get; set; }
    }
}
