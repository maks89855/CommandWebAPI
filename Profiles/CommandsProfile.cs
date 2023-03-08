using AutoMapper;
using CommandWebAPI.Dto;
using CommandWebAPI.Models;

namespace CommandWebAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
        }
    }
}
