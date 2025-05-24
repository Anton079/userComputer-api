using AutoMapper;
using UserComputer_api.Computers.Dtos;
using UserComputer_api.Computers.Models;

namespace UserComputer_api.Computers.Mappers
{
    public class ComputerMappingProfile:Profile
    {
        public ComputerMappingProfile()
        {
            CreateMap<ComputerRequest, Computer>();
            CreateMap<Computer, ComputerResponse>();
            CreateMap<List<Computer>, GetAllComputerDto>();

        }
    }
}
