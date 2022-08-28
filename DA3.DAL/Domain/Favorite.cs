namespace DA3.DAL.Domain
{
    public class Favorite : BaseDomain
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string ProductId { get; set; }
    }
}
