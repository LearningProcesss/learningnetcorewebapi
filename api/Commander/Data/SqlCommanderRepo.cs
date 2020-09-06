using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext context;

        public SqlCommanderRepository(CommanderContext context)
        {
            this.context = context;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            context.Commands.Add(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return this.context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return this.context.Commands.FirstOrDefault(item => item.Id == id);
        }
        public void UpdateCommand(Command command)
        {
            // EF not need nothing to do.
        }
        public bool SaveChanges()
        {
            return (this.context.SaveChanges() >= 0);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            context.Commands.Remove(command);
        }

        public void RemoveCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}