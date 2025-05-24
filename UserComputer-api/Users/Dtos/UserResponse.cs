using UserComputer_api.Computers.Dtos;
using UserComputer_api.Computers.Models;

namespace UserComputer_api.Users.Dtos
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Phone { get; set; }

        public List<ComputerResponse> Computers { get; set; } = new();
    }
}
