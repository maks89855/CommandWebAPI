using CommandWebAPI.Models;

namespace CommandWebAPI.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
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
    }
}
