using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public MockCommanderRepository()
        {
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
                new Command { Id = 0, HowTo = "Boil an Egg", Line = "Boil water", Platform = "Kettle e Pan" },
                new Command { Id = 1, HowTo = "Cut bread", Line = "Boil water", Platform = "Kettle e Pan" },
                new Command { Id = 2, HowTo = "Add butter", Line = "Boil water", Platform = "Kettle e Pan" },
                new Command { Id = 3, HowTo = "Add jam", Line = "Boil water", Platform = "Kettle e Pan" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil na Egg", Line = "Boil water", Platform = "Kettle e Pan" };
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}