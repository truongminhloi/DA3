using DA3.Common;

namespace DA3.DAL.Domain
{
    public class Account : BaseDomain
    {
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public DateTime? DayOfBirth { get; set; }

        public string? Password { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        //public virtual List<Favorite>? Favorites { get; set; }

        //public virtual Cart Cart { get; set; }

        //public virtual Order Order { get; set; }

        public Status Status { get; set; }
    }
}
