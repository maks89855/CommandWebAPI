using CommandWebAPI.Data;
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
        public CommandsController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;    
        }
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandsItems = _applicationRepository.GetAllCommand();
            return Ok(commandsItems);
        }
        //GET api/commands/id
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandsByID = _applicationRepository.GetCommandById(id);
            return Ok(commandsByID);
        }
    }
}
