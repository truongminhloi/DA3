using DA3.Common;
using DA3.Common.Enums;

namespace DA3.DAL.Domain
{
    public class Cart : BaseDomain
    {
        public virtual Guid Id { get; set; }

        public virtual string? UserId { get; set; }

        public virtual List<CartDetails> CartDetails { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }

        public virtual string? Address { get; set; }

        public virtual Status Status { get; set; }
    }
}
