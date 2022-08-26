namespace DA3.DAL.Domain
{
    public class Store : BaseDomain
    {
        public Guid Id { get; set; }

        public string StoreName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
