using AutoMapper;
using CommandWebAPI.Dto;
using CommandWebAPI.Models;

namespace CommandWebAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source => Target
            CreateMap<Command, CommandReadDto>();
            
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
