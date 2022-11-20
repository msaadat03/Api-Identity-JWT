using System.ComponentModel.DataAnnotations;

namespace Service.DTO_s.Account
{
    public class LoginDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
