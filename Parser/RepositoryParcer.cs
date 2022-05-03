using Entities.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Parser
{
    public class RepositoryParcer : RepositoryContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=3Opelkadett3_;Server=localhost;Port=5432;Database=formula;Integrated Security=true;Pooling=true;");
        }
    }
}
