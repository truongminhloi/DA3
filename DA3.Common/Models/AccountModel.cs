using DA3.Common;

namespace DA3.Models
{
    public class AccountModel : BaseModel
    {
        public string Id { get; set; }

        public string? FullName { get; set; }

        public DateTime? DayOfBirth { get; set; }

        public string? Password { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public Status Status { get; set; }
    }
}
