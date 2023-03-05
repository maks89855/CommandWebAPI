using CommandWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandWebAPI.Data
{
    public class CommandContext: DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> opt):base()
        {
            
        }
        public DbSet<Command> Commands { get; set; }
    }
}
