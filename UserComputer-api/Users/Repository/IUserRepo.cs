using UserComputer_api.Computers.Dtos;
using UserComputer_api.Users.Dtos;
using UserComputer_api.Users.Models;

namespace UserComputer_api.Users.Repository
{
    public interface IUserRepo
    {
        Task<GetAllUserDto> GetAllAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> FindByNameUserasync(string name);
        Task<User?> GetEntityByIdasync(int id);
        Task<UserResponse> CreateUserAsync(UserRequest userReq);
        Task<UserResponse> UpdateUser(int id, UserUpdateRequest userUpdate);
        Task UpdateAsync(User user);
        Task<UserResponse> DeleteUserAsync(int id);

        Task<ComputerResponse> DeleteComputerAsync(int idUser, int idComputer);
        Task<ComputerResponse> UpdateComputerAsync(int idUser, int idComputer, ComputerUpdateRequest request);
    }
}
