using UserComputer_api.Users.Models;

namespace UserComputer_api.Users.Dtos
{
    public class GetAllUserDto
    {
        public List<UserResponse> ListUser { get; set; }
    }
}
