using CommandWebAPI.Models;

namespace CommandWebAPI.Data
{
    public interface IApplicationRepository
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommand();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);   
        void DeleteCommand(Command command);
    }
}
