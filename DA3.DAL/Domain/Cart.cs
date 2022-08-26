using DA3.Common;
using DA3.Common.Enums;

namespace DA3.DAL.Domain
{
    public class Cart : BaseDomain
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public List<CartDetails> CartDetails { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public string Address { get; set; }

        public Status Status { get; set; }
    }
}
