namespace DA3.Models
{
    public class CheckoutViewModel
    {
        public AccountModel AccountModel { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string Note { get; set; }

        public string PayMethod { get; set; }

        public CartModel CartModel { get; set; }
    }
}