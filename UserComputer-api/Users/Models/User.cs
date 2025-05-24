using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserComputer_api.Computers.Models;

namespace UserComputer_api.Users.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }   

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("phone")]
        public int Phone {  get; set; }

        public virtual List<Computer> Computers { get; set; } = new();
    }
}
