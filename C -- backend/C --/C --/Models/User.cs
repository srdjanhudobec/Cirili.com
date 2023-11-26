using Microsoft.AspNetCore.Identity;

namespace C___.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
