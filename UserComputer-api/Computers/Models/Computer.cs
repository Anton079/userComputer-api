using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using UserComputer_api.Users.Models;

namespace UserComputer_api.Computers.Models
{
    [Table("computers")]
    public class Computer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("type")]
        public string Type { get; set; }    

        [Required]
        [Column("model")]
        public string Model { get; set; }

        [Required]
        [Column("price")]
        public int Price { get; set; }

        public virtual User Users { get; set; }

        public int UserId { get; set; }
    }
}
