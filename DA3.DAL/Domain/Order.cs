namespace DA3.DAL.Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }
        
        public double TotalPrice { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
