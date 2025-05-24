using AutoMapper;
using UserComputer_api.Computers.Dtos;
using UserComputer_api.Computers.Exceptions;
using UserComputer_api.Computers.Models;
using UserComputer_api.Data;
using UserComputer_api.Users.Dtos;
using UserComputer_api.Users.Exceptions;
using UserComputer_api.Users.Models;
using UserComputer_api.Users.Repository;

namespace UserComputer_api.Users.Service
{
    public class CommandServiceUser : ICommandServiceUser
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _userReo;

        public CommandServiceUser(IUserRepo userRepo, IMapper mapper)
        {
            _userReo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest userReq)
        {
            UserResponse verif = await _userReo.FindByNameUserasync(userReq.Name);

            if(verif == null)
            {
                UserResponse response = await _userReo.CreateUserAsync(userReq);

                return response;
            }
            throw new UserNotFoundException();
        }

        public async Task<UserResponse> UpdateUserAsync(int id,UserUpdateRequest update)
        {
            UserResponse verf = await _userReo.GetByIdAsync(id);

            if(verf != null)
            {
                if(verf is UserResponse)
                {
                    verf.Name =update.Name ?? verf.Name;
                    verf.Email =update.Email ?? verf.Email;
                    verf.Password =update.Password ?? verf.Password;
                    verf.Phone =update.Phone ?? verf.Phone;

                    UserResponse response = await _userReo.UpdateUser(id,update);

                    return response;
                }
            }
            throw new UserNotFoundException();
        }

        public async Task<UserResponse> DeleteUserAsync(int id)
        {
            UserResponse vef = await _userReo.GetByIdAsync(id);

            if(vef != null)
            {
                UserResponse response = await _userReo.DeleteUserAsync(id);

                return response;
            }
            throw new UserNotFoundException();
        }

        //Computer
        public async Task<ComputerResponse> AddComputerAsync(ComputerRequest req)
        {
            var user = await _userReo.GetEntityByIdasync(req.UserId);
            if (user == null)
                throw new UserNotFoundException();

            var computer = _mapper.Map<Computer>(req);


            user.Computers.Add(computer);

            await _userReo.UpdateAsync(user);

            return _mapper.Map<ComputerResponse>(computer);
        }

        public async Task<ComputerResponse> UpdatecomputerAsync(int idUser, int idComputer,ComputerUpdateRequest updateRequest)
        {
            UserResponse usr = await _userReo.GetByIdAsync(idUser);
            ComputerResponse comp = usr.Computers.FirstOrDefault(x => x.Id == idComputer);

            if(comp != null)
            {
                if(comp is ComputerRequest)
                {
                    comp.Model = updateRequest.Model ?? comp.Model;

                    ComputerResponse response = await _userReo.UpdateComputerAsync(idUser, idComputer, updateRequest);
                    return response;
                }
            }
            throw new ComputerNotFoundException();
        }

        public async Task<ComputerResponse> DeleteComputerAsync(int idUser, int idComputer)
        {
            User usr = await _userReo.GetEntityByIdasync(idUser);
            Computer comp = usr.Computers.FirstOrDefault(x => x.Id == idComputer);

            if(usr != null)
            {
                if(comp != null)
                {
                    ComputerResponse resp = await _userReo.DeleteComputerAsync(idUser, idComputer);

                    return resp;
                }
                throw new ComputerNotFoundException();
            }
            throw new UserNotFoundException();
        }

       
    }
}
