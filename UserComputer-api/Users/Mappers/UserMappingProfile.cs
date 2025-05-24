using AutoMapper;
using System.Configuration;
using UserComputer_api.Users.Dtos;
using UserComputer_api.Users.Models;

namespace UserComputer_api.Users.Mappers
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<UserUpdateRequest, User>();

            CreateMap<User, UserResponse>()

                .ForMember(dest=>dest.Computers, opt=>opt.MapFrom(src=>src.Computers));
        }
    }
}
