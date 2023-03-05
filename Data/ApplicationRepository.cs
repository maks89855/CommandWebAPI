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
        public IEnumerable<Command> GetAllCommand()
        {
            return _ctx.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _ctx.Commands.FirstOrDefault(x => x.Id == id);
        }
    }
}
