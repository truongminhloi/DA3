using DA3.Common;
using DA3.Common.Enums;

namespace DA3.Models
{
    public class OrderModel : BaseModel
    {
        public virtual string Id { get; set; }

        public virtual string? UserId { get; set; }

        public virtual DateTime? DeliveryDate { get; set; }

        public virtual string Note { get; set; }

        public virtual string PayMethod { get; set; }

        public virtual decimal TotalPrice { get; set; }

        public virtual List<OrderDetailModel> OrderDetailModel { get; set; }

        public virtual StatusOrder Status { get; set; }
    }
}