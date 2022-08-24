namespace DA3.DAL.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public double TotalPrice { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
