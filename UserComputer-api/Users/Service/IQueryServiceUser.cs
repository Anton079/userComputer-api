using UserComputer_api.Users.Dtos;

namespace UserComputer_api.Users.Service
{
    public interface IQueryServiceUser
    {
        Task<UserResponse> GetByIdAsync(int id);

        Task<GetAllUserDto> GetAllAsync();
    }
}
