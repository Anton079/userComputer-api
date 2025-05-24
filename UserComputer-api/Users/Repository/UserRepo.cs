using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserComputer_api.Computers.Dtos;
using UserComputer_api.Computers.Models;
using UserComputer_api.Data;
using UserComputer_api.Users.Dtos;
using UserComputer_api.Users.Models;

namespace UserComputer_api.Users.Repository
{
    public class UserRepo:IUserRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UserRepo(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;   
        }

        //user
        public async Task<GetAllUserDto> GetAllAsync()
        {
            var user = await _appDbContext.Users
                .Include(u => u.Computers)
                .ToListAsync();

            var mapped = _mapper.Map<List<UserResponse>>(user);

            return new GetAllUserDto
            {
                ListUser = mapped
            };
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await _appDbContext.Users
                .Include(u => u.Computers)
                .FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> FindByNameUserasync(string name)
        {
            User searched = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Name == name);

            UserResponse response = _mapper.Map<UserResponse>(searched);

            return response;
        }

        public async Task<User?> GetEntityByIdasync(int id)
        {
            return await _appDbContext.Users
                .Include(u => u.Computers)  
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest userReq)
        {
            var userEntity = _mapper.Map<User>(userReq);

            await _appDbContext.Users.AddAsync(userEntity);
            await _appDbContext.SaveChangesAsync();
            var userResponse = _mapper.Map<UserResponse>(userReq);
            return userResponse;
        }

        public async Task<UserResponse> UpdateUser(int id, UserUpdateRequest userUpdate)
        {
            User exist = await _appDbContext.Users.FindAsync(id);

            if (userUpdate.Name != null)
            {
                exist.Name = userUpdate.Name;
            }
            if (userUpdate.Email != null)
            {
                exist.Email = userUpdate.Email;
            }
            if (userUpdate.Password != null)
            {
                exist.Password = userUpdate.Password;
            }
            if (userUpdate.Phone != null)
            {
                exist.Phone = userUpdate.Phone.Value;
            }

            _appDbContext.Users.Update(exist);

            await _appDbContext.SaveChangesAsync();

            UserResponse response = _mapper.Map<UserResponse>(exist);

            return response;
        }

        public async Task UpdateAsync(User user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<UserResponse> DeleteUserAsync(int id)
        {
            User user = await _appDbContext.Users.FindAsync(id);
            UserResponse response = _mapper.Map<UserResponse>(user);

            _appDbContext.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return response;
        }

        
        //Computer

        public async Task<ComputerResponse> DeleteComputerAsync(int idUser, int idComputer)
        {
            User user = await GetEntityByIdasync(idUser);

            Computer searched = user.Computers.FirstOrDefault(u => u.Id == idComputer);

            if(searched != null)
            {
                user.Computers.Remove(searched);
            }
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<ComputerResponse>(user);
        }

        public async Task<ComputerResponse> UpdateComputerAsync(int idUser, int idComputer, ComputerUpdateRequest request)
        {
            User user = await GetEntityByIdasync(idUser);

            Computer searched = user.Computers.FirstOrDefault(u =>u.Id == idComputer);  

            if(searched != null)
            {
                user.Computers.Remove(searched);
            }
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<ComputerResponse>(user);
        }
    }
}
