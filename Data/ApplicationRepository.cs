using CommandWebAPI.Models;

namespace CommandWebAPI.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly CommandContext _ctx;
        public ApplicationRepository(CommandContext commandContext)
        {
            _ctx = commandContext;
        }

        public void CreateCommand(Command command)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));
            _ctx.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            _ctx.Commands.Remove(command);
            _ctx.SaveChanges();
        }

        public IEnumerable<Command> GetAllCommand()
        {
            return _ctx.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _ctx.Commands.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges()>=0);

        }

        public void UpdateCommand(Command command)
        {
            
        }
    }
}
