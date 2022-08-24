using System.ComponentModel.DataAnnotations;

namespace DA3.Service.Request
{
    public class LoginRequest
    {
        [Required]
        public string LoginId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
