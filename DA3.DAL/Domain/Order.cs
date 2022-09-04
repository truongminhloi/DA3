using DA3.Common;

namespace DA3.DAL.Domain
{
    public class Order : BaseDomain
    {
        public virtual Guid Id { get; set; }

        public virtual string? UserId { get; set; }

        //public virtual Account Account { get; set; }

        public virtual DateTime? DeliveryDate { get; set; }

        public virtual string? Note { get; set; }

        public virtual string PayMethod { get; set; }

        public virtual double TotalPrice { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }

        public virtual StatusOrder Status { get; set; }
    }
}
