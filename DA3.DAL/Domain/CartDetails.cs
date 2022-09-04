using DA3.Common;

namespace DA3.DAL.Domain
{
    public class CartDetails : BaseDomain
    {
        public virtual Guid Id { get; set; }

        public virtual string? CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual string? ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual int Quantity { get; set; }

        public virtual Status Status { get; set; }
    }
}
