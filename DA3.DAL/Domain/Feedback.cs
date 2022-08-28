namespace DA3.DAL.Domain
{
    public class Feedback : BaseDomain
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Problem { get; set; }

        public string? Message { get; set; }
    }
}
