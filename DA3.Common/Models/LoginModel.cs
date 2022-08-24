using System.ComponentModel.DataAnnotations;

namespace DA3.Models
{
    public class LoginModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string Fullname { get; set; }
    }
}