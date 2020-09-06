using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // api/commands 
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository repository;
        private readonly IMapper mapper;

        // DependencyInjection, comes from startup.cs ConfigureServices
        public CommandsController(ICommanderRepository commanderRepository, IMapper mapper)
        {
            this.repository = commanderRepository;
            this.mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var items = repository.GetAllCommands();

            return Ok(this.mapper.Map<IEnumerable<CommandReadDto>>(items));
        }

        // GET api/commands/{id} -> api/commands/5
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var item = repository.GetCommandById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<CommandReadDto>(item));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandWriteDto command)
        {
            var commandModel = mapper.Map<Command>(command);

            repository.CreateCommand(commandModel);

            repository.SaveChanges();

            var commanderReadDto = mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commanderReadDto.Id }, commanderReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModel = repository.GetCommandById(id);

            if (commandModel == null) { return NotFound(); }

            mapper.Map(commandUpdateDto, commandModel);

            repository.UpdateCommand(commandModel);

            repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patcherDoc)
        {
            var commandModel = repository.GetCommandById(id);

            if (commandModel == null) { return NotFound(); }

            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModel);

            patcherDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(commandToPatch, commandModel);

            repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModel = repository.GetCommandById(id);

            if (commandModel == null) { return NotFound(); }

            repository.DeleteCommand(commandModel);

            return NoContent();
        }
    }
}