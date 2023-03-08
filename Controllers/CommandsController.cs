using AutoMapper;
using CommandWebAPI.Data;
using CommandWebAPI.Dto;
using CommandWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CommandWebAPI.Controllers
{
    //api/commands
    [Route("api/commands")] 
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        public CommandsController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;   
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandsItems = _applicationRepository.GetAllCommand();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandsItems));
        }
        //GET api/commands/id
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandsByID = _applicationRepository.GetCommandById(id);
            if(commandsByID != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandsByID));
            }
            return NotFound();
        }
    }
}
