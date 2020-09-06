using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {

        }
    }
}