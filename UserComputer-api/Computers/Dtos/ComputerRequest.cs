using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UserComputer_api.Users.Models;

namespace UserComputer_api.Computers.Dtos
{
    public class ComputerRequest
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }

        public int UserId { get; set; }
    }
}
