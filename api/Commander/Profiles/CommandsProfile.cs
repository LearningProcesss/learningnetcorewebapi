using Commander.Models;
using Commander.Dtos;
using AutoMapper;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandWriteDto, Command>();

            CreateMap<CommandUpdateDto, Command>();

            CreateMap<Command, CommandUpdateDto>();
        }
    }
}