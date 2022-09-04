using DA3.Common;
using DA3.Common.Enums;

namespace DA3.Models
{
    public class OrderDetailModel : BaseModel
    {
        public virtual string Id { get; set; }

        public string? OrderId { get; set; }

        public virtual string? ProductId { get; set; }

        public virtual double Price { get; set; }

        public virtual int Quantity { get; set; }
    }
}