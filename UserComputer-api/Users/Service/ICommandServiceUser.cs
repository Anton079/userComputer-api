using UserComputer_api.Computers.Dtos;
using UserComputer_api.Users.Dtos;

namespace UserComputer_api.Users.Service
{
    public interface ICommandServiceUser
    {
        Task<UserResponse> CreateUserAsync(UserRequest userReq);
        Task<UserResponse> UpdateUserAsync(int id, UserUpdateRequest update);
        Task<UserResponse> DeleteUserAsync(int id);
        Task<ComputerResponse> AddComputerAsync(ComputerRequest req);
        Task<ComputerResponse> UpdatecomputerAsync(int idUser, int idComputer, ComputerUpdateRequest updateRequest);
        Task<ComputerResponse> DeleteComputerAsync(int idUser, int idComputer);
    }
}
