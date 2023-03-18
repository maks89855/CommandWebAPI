using AutoMapper;
using CommandWebAPI.Data;
using CommandWebAPI.Dto;
using CommandWebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int Id)
        {
            var commandsByID = _applicationRepository.GetCommandById(Id);
            if(commandsByID != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandsByID));
            }
            return NotFound();
        }
        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _applicationRepository.CreateCommand(commandModel);
            _applicationRepository.SaveChanges();
            var commandReadTo = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadTo.Id }, commandReadTo);
        }
        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int Id, CommandUpdateDto commandUpdateDto)
        {
            var command = _applicationRepository.GetCommandById(Id);
            if(command == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, command);
            _applicationRepository.UpdateCommand(command);
            _applicationRepository.SaveChanges();
            return NoContent();
        }

        //PACTH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int Id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var command = _applicationRepository.GetCommandById(Id);
            if (command == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDto>(command);
            patchDocument.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch)) 
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, command);
            _applicationRepository.UpdateCommand(command);
            _applicationRepository.SaveChanges();
            return NoContent();
        }
        //DELETE api/command{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int Id)
        {
            var command = _applicationRepository.GetCommandById(Id);
            if (command == null)
            {
                return NotFound();
            }
            _applicationRepository.DeleteCommand(command);
            _applicationRepository.SaveChanges();
            return NoContent();
        }
    }
}
