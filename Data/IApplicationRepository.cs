using CommandWebAPI.Models;

namespace CommandWebAPI.Data
{
    public interface IApplicationRepository
    {
        IEnumerable<Command> GetAllCommand();
        Command GetCommandById(int id);
    }
}
