using AutoMapper;
using UserComputer_api.Data;
using UserComputer_api.Users.Dtos;
using Microsoft.EntityFrameworkCore;

namespace UserComputer_api.Users.Service
{
    public class QueryServiceUser : IQueryServiceUser
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QueryServiceUser(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllUserDto> GetAllAsync()
        {
            var users = await _context.Users
                .Include(u => u.Computers)
                .ToListAsync();

            var mapped = _mapper.Map<List<UserResponse>>(users);

            return new GetAllUserDto { ListUser = mapped };
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Computers)
                .FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<UserResponse>(user);
        }
    }
}
