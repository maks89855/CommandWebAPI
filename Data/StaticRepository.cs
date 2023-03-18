using CommandWebAPI.Models;

namespace CommandWebAPI.Data
{
    public class StaticRepository
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommand()
        {
            var commands = new List<Command>() 
            {
                new Command { Id=1, HowTo="", Line="", Platform=""},
                new Command { Id=2, HowTo="", Line="", Platform=""},
                new Command { Id=3, HowTo="", Line="", Platform=""},
                new Command { Id=4, HowTo="", Line="", Platform=""},
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "", Line = "", Platform = "" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
