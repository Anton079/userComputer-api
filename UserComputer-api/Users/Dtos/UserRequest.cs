using System.ComponentModel.DataAnnotations;

namespace UserComputer_api.Users.Dtos
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Phone {  get; set; }


    }
}
