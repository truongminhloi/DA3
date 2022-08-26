using System.ComponentModel.DataAnnotations;

namespace DA3.Models
{
    public class LoginModel : BaseModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReEnterPassword { get; set; }

        public string FullName { get; set; }
    }
}