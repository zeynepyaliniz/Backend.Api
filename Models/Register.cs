using DataAnnotationsExtensions;

namespace Backend.Api.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        [Email]
        public string Email { get; set; }
        [Email]
        public string ConfirmedEmail { get; set; }
    }

}
